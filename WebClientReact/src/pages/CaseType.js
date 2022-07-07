import { Icon } from '@iconify/react';
import { sentenceCase } from 'change-case';
import React, { useEffect, useState } from 'react';
import plusFill from '@iconify/icons-eva/plus-fill';
import roundUpdate from '@iconify/icons-ic/round-update';
import CloseIcon from '@material-ui/icons/Close';
// material
import {
    Card,
    Table,
    Stack,
    Button,
    TableRow,
    TableBody,
    TableCell,
    Container,
    Typography,
    TableContainer,
    Box,
    Paper,
    TableHead,
    TextField, InputAdornment, IconButton
} from '@mui/material';
// components
import FormControl from '@mui/material/FormControl';
import MenuItem from '@mui/material/MenuItem';
import Modal from '@mui/material/Modal';
import Switch from '@mui/material/Switch';
import AuthService from '../services/auth.service';
import Page from '../components/Page';
import Label from '../components/Label';
import Scrollbar from '../components/Scrollbar';
import CourtOfficeTypesService from '../services/courtOfficeType.service';
import PopupMessageService from '../services/popupMessage.service';
import CaseTypeService from "../services/caseType.service";
import CircularProgress from "@mui/material/CircularProgress";
import AccountBalanceOutlinedIcon from '@mui/icons-material/AccountBalanceOutlined';
import ToggleOffOutlinedIcon from '@mui/icons-material/ToggleOffOutlined';
import DriveFileRenameOutlineOutlinedIcon from '@mui/icons-material/DriveFileRenameOutlineOutlined';
import {Global} from "../Global";
import trash2Outline from "@iconify/icons-eva/trash-2-outline";
import Alert from "@mui/material/Alert";

// ----------------------------------------------------------------------


export default function CaseType() {
    const [courtOfficeTypes, setCourtOfficeTypes] = useState([]);
    const [caseTypes, setCaseTypes] = useState([]);
    const [statusForAdd, setStatusForAdd] = useState(true);
    const [courtOfficeTypeAdd, setCourtOfficeTypeAdd] = useState("");
    const [openModal, setOpen] = useState(false);
    const [profileName, setProfileName] = useState('');
    const [caseTypeUpdateId, setCaseTypeUodateId] = useState(0);
    const [errorMessage, setErrorMessage] = useState('');
    const [courtOfficeTypeIdForFilter, setCourtOfficeTypeIdForFilter] = useState(-1);
    const [isActiveForFilter, setIsActiveForFilter] = useState(-1);
    const [isLoading, setIsLoading] = useState(true);
    const [isErrorMessage, setIsErrorMessage] = useState(false);

    const caseTypeService = new CaseTypeService();
    const popupMessageService = new PopupMessageService();
    const authService = new AuthService();
    const catchMessagee = Global.catchMessage;


    //Changing Activity of the current Case Status
    const changeActivity = (cId) => {
        caseTypeService.changeActivity2(cId).then(result => {
            getAllCaseTypes()
            popupMessageService.AlertSuccessMessage(result.data.Message);
        }, error => {
            popupMessageService.AlertErrorMessage(error.response.data.Message)
        }).catch(()=> {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    };
    function filtering(caseTypes) {
        let filteredCaseTypes = caseTypes
        if (courtOfficeTypeIdForFilter > 0)
            filteredCaseTypes = filteredCaseTypes.filter(c => c.CourtOfficeTypeGetDto.CourtOfficeTypeId === courtOfficeTypeIdForFilter)
        if (isActiveForFilter > -1)
            filteredCaseTypes = filteredCaseTypes.filter(c => c.IsActive == isActiveForFilter)
        return filteredCaseTypes
    }
    //List all the Case Statuses of current licence
    const getAllCaseTypes = () => {
            caseTypeService.getAll().then(
                (result) => {
                    if (result.data.Success) {
                        setCaseTypes(result.data.Data);
                        setIsLoading(false)
                    }
                },
                (error) => {
                    popupMessageService.AlertErrorMessage(error.response.data.Message);
                }
            ).catch(()=> {
                popupMessageService.AlertErrorMessage(catchMessagee)
            })
        }
    // List all court office types
    const getAllCourtOfficeTypes = () => {
        const courtOfficeTypesService = new CourtOfficeTypesService();
        courtOfficeTypesService
            .getAll()
            .then(
                (response) => {
                    setCourtOfficeTypes(response.data.Data);
                    const CourtOfficeFromApi = response.data.Data;
                    const list = [];
                    CourtOfficeFromApi.forEach((item) => {
                        list.push({
                            value: item.CourtOfficeTypeId,
                            label: item.CourtOfficeTypeName,
                            key: item.CourtOfficeTypeName
                        });
                    });
                    if(list.length > 0) {
                        setCourtOfficeTypeAdd(list[0].value)
                    }
                    setCourtOfficeTypes(list);
                },
                (error) => {
                    popupMessageService.AlertErrorMessage(error.response.data.Message);
                }
            )
            .catch(() => {
                popupMessageService.AlertErrorMessage(catchMessagee)
            });
    };

    function deleteCaseType(id) {
        caseTypeService.delete(id).then(result => {
                if (result.data.Success) {
                    getAllCaseTypes()
                    popupMessageService.AlertSuccessMessage(result.data.Message);
                }
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    };

    const createRandomKey = () => {
        return Math.random().toString(36).substr(2, 9);
    }

    const handleOpen = () => {
        setProfileName("")
        setStatusForAdd(true)
        setCourtOfficeTypeAdd(courtOfficeTypes[0].value)
        setCaseTypeUodateId(0)
        setIsErrorMessage(false)
        setErrorMessage("")
        setOpen(true);
    };
    const handleClose = () => {
        setOpen(false);
    };

    useEffect(() => {
        getAllCourtOfficeTypes();
        getAllCaseTypes();
    }, []);

    const handleChangeCourtOffice = (event) => {
        setCourtOfficeTypeAdd(event.target.value);
    };
    const handleChangeStatus = (event) => {
        setStatusForAdd(event.target.value);
    };

    const addNewRecord = () => {
        let obj = {
            courtOfficeTypeId: courtOfficeTypeAdd,
            description: profileName,
            isActive: statusForAdd
        }
        let re
        if (caseTypeUpdateId > 0) {
            obj.CaseTypeId = caseTypeUpdateId
            re = caseTypeService.update(obj)
        }
        else {
            re = caseTypeService.add(obj)
        }
        re.then(
            (result) => {
                if (result.data.Success) {
                    getAllCaseTypes()
                    setOpen(false)
                    popupMessageService.AlertSuccessMessage(result.data.Message)
                }
            },
            (error) => {
                setIsErrorMessage(true)
                setErrorMessage(error.response.data.Message);
            }
        ).catch(()=> {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    };


    function openModelForUpdate(id) {
        caseTypeService.getById(id).then(result => {
            if (result.data.Success) {
                let caseTypeUpdate = result.data.Data
                setProfileName(caseTypeUpdate.Description)
                setStatusForAdd(caseTypeUpdate.IsActive)
                setCourtOfficeTypeAdd(caseTypeUpdate.CourtOfficeTypeGetDto.CourtOfficeTypeId)
                setCaseTypeUodateId(caseTypeUpdate.CaseTypeId)
            }
        })
        setOpen(true)
    }
    return (
        <Page title="Case Type | MediLaw">
            <Container>
                <Stack direction="row" alignItems="center" justifyContent="space-between" mb={4}>
                    <Typography variant="h4" gutterBottom>
                        Case Type
                    </Typography>
                    {authService.DoesHaveMandatoryClaim('CaseTypeAdd') || authService.DoesHaveMandatoryClaim('LicenceOwner') ? (
                        <>
                            <Button onClick={handleOpen} variant="contained" startIcon={<Icon icon={plusFill} />}>
                                New Record
                            </Button>
                            <Modal sx={{ backgroundColor: "rgba(0, 0, 0, 0.5)" }}
                                   hideBackdrop={true}
                                   disableEscapeKeyDown={true}
                                   open={openModal}
                                   aria-labelledby="modal-modal-title"
                                   aria-describedby="modal-modal-description"
                            >
                                <Box
                                    sx={{

                                        position: 'absolute',
                                        top: '50%',
                                        left: '50%',
                                        transform: 'translate(-50%, -50%)',
                                        width: 470,
                                        backgroundColor: 'background.paper',
                                        border: '2px solid #fff',
                                        p: 4,
                                        borderRadius: 2
                                    }}
                                >
                                    <Stack mb={5} flexDirection="row" justifyContent='space-between'>
                                        {caseTypeUpdateId > 0 ?
                                            <Typography id="modal-modal-title" variant="h6" component="h2">
                                                Edit record!
                                            </Typography>
                                            :
                                            <Typography id="modal-modal-title" variant="h6" component="h2">
                                                Add new record!
                                            </Typography>
                                        }
                                        <IconButton sx={{bottom:4}}>
                                        <CloseIcon onClick={handleClose}/>
                                        </IconButton>
                                    </Stack>
                                    <Stack spacing={2} >
                                        <Stack mb={2} alignItems="center" justifyContent="space-around">
                                            <Stack mb={3} justifyContent="space-around">
                                                <Box sx={{ minWidth: 400 }}>
                                                    <TextField
                                                        autoFocus
                                                        fullWidth
                                                        size="small"
                                                        label="Case Type Name"
                                                        value={profileName}
                                                        onChange={(event) => setProfileName(event.target.value)}
                                                        InputProps={{
                                                            startAdornment: (
                                                                <InputAdornment position="start">
                                                                    <DriveFileRenameOutlineOutlinedIcon />
                                                                </InputAdornment>
                                                            )
                                                        }}
                                                    />
                                                </Box>
                                            </Stack>
                                            <Stack mb={3} justifyContent="space-around">
                                                {courtOfficeTypes.length > 0 ? (
                                                    <Box sx={{ minWidth: 400 }}>
                                                        <FormControl fullWidth size="small">
                                                            <TextField
                                                                select
                                                                size='small'
                                                                labelId="demo-simple-select-label"
                                                                id="demo-simple-select"
                                                                label="Court Office"
                                                                value={courtOfficeTypeAdd}
                                                                key={Math.random().toString(36).substr(2, 9)}
                                                                onChange={handleChangeCourtOffice}
                                                                InputProps={{
                                                                    startAdornment: (
                                                                        <InputAdornment position="start">
                                                                            <AccountBalanceOutlinedIcon />
                                                                        </InputAdornment>
                                                                    )
                                                                }}
                                                            >

                                                                {courtOfficeTypes.map((item) => (
                                                                    <MenuItem
                                                                        key={Math.random().toString(36).substr(2, 9)}
                                                                        value={item.value}
                                                                    >
                                                                        {item.label}
                                                                    </MenuItem>
                                                                ))}
                                                            </TextField>
                                                        </FormControl>
                                                    </Box>
                                                ) : null}
                                            </Stack>
                                            <Stack justifyContent="space-around">
                                                <Box sx={{ minWidth: 400 }}>
                                                    <FormControl fullWidth size="small">
                                                        <TextField
                                                            select
                                                            size='small'
                                                            labelId="demo-simple-select-label"
                                                            id="demo-simple-select"
                                                            value={statusForAdd}
                                                            key={createRandomKey}
                                                            onChange={handleChangeStatus}
                                                            label="Status"
                                                            InputProps={{
                                                                startAdornment: (
                                                                    <InputAdornment position="start">
                                                                        <ToggleOffOutlinedIcon />
                                                                    </InputAdornment>
                                                                )
                                                            }}
                                                        >
                                                            <MenuItem key={createRandomKey} value>
                                                                Active
                                                            </MenuItem>
                                                            <MenuItem key={createRandomKey} value={false}>
                                                                Passive
                                                            </MenuItem>
                                                        </TextField>
                                                    </FormControl>
                                                </Box>
                                            </Stack>
                                        </Stack>
                                        {caseTypeUpdateId > 0 ?
                                            <Button sx={{top: 0}} size="large" type="submit" variant="contained"
                                                    onClick={() => addNewRecord()}>Edit!</Button>
                                            :
                                            <Button sx={{top: 0}} size="large" type="submit" variant="contained"
                                                    onClick={() => addNewRecord()}>Add!</Button>
                                        }
                                        {isErrorMessage ?
                                            <Alert severity="error">{errorMessage}</Alert>
                                            : null}
                                    </Stack>
                                </Box>
                            </Modal>
                        </>
                    ) : null}
                </Stack>
                <Stack mb={5} flexDirection="row" alignItems="center" justifyContent="space-around">
                    <Stack mb={5} justifyContent="space-around">
                        <Typography variant="body1" gutterBottom mb={3}>
                            Court Office Type
                        </Typography>
                        {courtOfficeTypes.length > 0 ? (
                            <Box sx={{ minWidth: 400 }}>
                                <FormControl fullWidth size="small">
                                    <TextField
                                        select
                                        size='small'
                                        labelId="demo-simple-select-label"
                                        id="demo-simple-select"
                                        label="Court Office Type"
                                        value={courtOfficeTypeIdForFilter}
                                        key={Math.random().toString(36).substr(2, 9)}
                                        onChange={(e) => setCourtOfficeTypeIdForFilter(e.target.value)}
                                        InputProps={{
                                            startAdornment: (
                                                <InputAdornment position="start">
                                                    <AccountBalanceOutlinedIcon />
                                                </InputAdornment>
                                            )
                                        }}
                                    >
                                        <MenuItem key={Math.random().toString(36).substr(2, 9)} value={-1}>
                                            All
                                        </MenuItem>
                                        {courtOfficeTypes.map((item) => (
                                            <MenuItem key={Math.random().toString(36).substr(2, 9)} value={item.value}>
                                                {item.label}
                                            </MenuItem>
                                        ))}
                                    </TextField>

                                </FormControl>
                            </Box>
                        ) : null}
                    </Stack>
                    <Stack mb={5} justifyContent="space-around">
                        <Typography variant="body1" gutterBottom mb={3}>
                            Status
                        </Typography>
                        <Box sx={{ minWidth: 400 }}>
                            <FormControl fullWidth size="small">
                                <TextField
                                    select
                                    size='small'
                                    labelId="demo-simple-select-label"
                                    id="demo-simple-select"
                                    value={isActiveForFilter}
                                    key={Math.random().toString(36).substr(2, 9)}
                                    label="Status"
                                    onChange={(e) => setIsActiveForFilter(e.target.value)}
                                    InputProps={{
                                        startAdornment: (
                                            <InputAdornment position="start">
                                                <ToggleOffOutlinedIcon />
                                            </InputAdornment>
                                        )
                                    }}
                                >
                                    <MenuItem key={Math.random().toString(36).substr(2, 9)} value={-1}>All</MenuItem>
                                    <MenuItem key={Math.random().toString(36).substr(2, 9)} value={1}>
                                        Active
                                    </MenuItem>
                                    <MenuItem key={Math.random().toString(36).substr(2, 9)} value={0}>
                                        Passive
                                    </MenuItem>
                                </TextField>
                            </FormControl>
                        </Box>
                    </Stack>
                </Stack>
                <Card sx={{ marginTop: -3 }}>
                    <Scrollbar>
                        {isLoading === true ?
                            <Stack sx={{color: 'grey.500', padding: 10}} spacing={2} direction="row" justifyContent='center'>
                                <CircularProgress color="inherit"/>
                            </Stack>
                            :
                            <>
                                {caseTypes.length > 0 ? (
                                    <TableContainer component={Paper}>
                                        <Table sx={{minWidth: 650}} aria-label="simple table">
                                            <TableHead>
                                                <TableRow sx={{backgroundColor: '#f7f7f7'}}>
                                                    <TableCell sx={{paddingLeft: 7}}>Case Type Name</TableCell>
                                                    <TableCell align="left">Court Office Name</TableCell>
                                                    <TableCell align="left">Status</TableCell>
                                                    <TableCell align="left">Change Activity</TableCell>
                                                    <TableCell align="left">Edit</TableCell>
                                                    <TableCell align="left">delete</TableCell>
                                                    <TableCell align="right"/>
                                                </TableRow>
                                            </TableHead>
                                            <TableBody>
                                                <>
                                                    {
                                                        filtering(caseTypes)
                                                            .map((row) => (
                                                                <TableRow
                                                                    key={row.CaseTypeId}
                                                                    sx={{'&:last-child td, &:last-child th': {border: 0}}}
                                                                >
                                                                    <TableCell component="th" scope="row" sx={{paddingLeft: 7}}>
                                                                        {row.Description}
                                                                    </TableCell>
                                                                    <TableCell component="th" scope="row">
                                                                        {row.CourtOfficeTypeGetDto.CourtOfficeTypeName}
                                                                    </TableCell>
                                                                    {row.IsActive ? (
                                                                        <TableCell component="th" scope="row">
                                                                            <Label variant="ghost" color="success">
                                                                                {sentenceCase('Active')}
                                                                            </Label>
                                                                        </TableCell>
                                                                    ) : (
                                                                        <TableCell component="th" scope="row">
                                                                            <Label variant="ghost" color="error">
                                                                                {sentenceCase('Pasive')}
                                                                            </Label>
                                                                        </TableCell>
                                                                    )}
                                                                    <TableCell>
                                                                        <Switch
                                                                            sx={{left: 25}}
                                                                            checked={row.IsActive}
                                                                            onChange={() => changeActivity(row.CaseTypeId)}
                                                                            inputProps={{'aria-label': 'controlled'}}
                                                                        />
                                                                    </TableCell>
                                                                    <TableCell align="left">
                                                                        <Button
                                                                            variant="contained"
                                                                            onClick={() => openModelForUpdate(row.CaseTypeId)}
                                                                            sx={{backgroundColor: '#b1b9be'}}
                                                                            startIcon={<Icon icon={roundUpdate}/>}
                                                                        >
                                                                            Edit
                                                                        </Button>
                                                                    </TableCell>
                                                                    {authService.DoesHaveMandatoryClaim('CaseTypeDelete')  || authService.DoesHaveMandatoryClaim('LicenceOwner') ? (
                                                                        <>
                                                                    <TableCell align="left">
                                                                        <Button
                                                                            variant="contained"
                                                                            onClick={() =>
                                                                                deleteCaseType(row.CaseTypeId)}
                                                                            sx={{backgroundColor: '#c9505c'}}
                                                                            startIcon={<Icon icon={trash2Outline}/>}
                                                                        >
                                                                            Delete
                                                                        </Button>
                                                                    </TableCell>
                                                                        </>
                                                                    ) : null}
                                                                    <TableCell align="right"/>
                                                                </TableRow>
                                                            ))}
                                                </>
                                            </TableBody>
                                        </Table>
                                    </TableContainer>
                                ) : (
                                    <TableCell sx={{ width: '40%' }}>
                                        <img src="/static/illustrations/no.png" alt="login" />
                                        <Typography variant="h3" gutterBottom textAlign='center' color='#a9a9a9'>No Data Found!</Typography>
                                    </TableCell>
                                )}
                            </>
                        }
                    </Scrollbar>
                </Card>
            </Container>
        </Page >
    );
}

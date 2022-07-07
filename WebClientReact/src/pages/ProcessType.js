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
import ProcessTypeService from "../services/processType.service";
import CircularProgress from "@mui/material/CircularProgress";
import DriveFileRenameOutlineOutlinedIcon from "@mui/icons-material/DriveFileRenameOutlineOutlined";
import ToggleOffOutlinedIcon from '@mui/icons-material/ToggleOffOutlined';
import {Global} from "../Global";
import Alert from "@mui/material/Alert";

// ----------------------------------------------------------------------


export default function ProcessType() {
    const [courtOfficeTypes, setCourtOfficeTypes] = useState([]);
    const [processTypes, setProcessTypes] = useState([]);
    const [statusForAdd, setStatusForAdd] = useState(true);
    const [courtOfficeTypeAdd, setCourtOfficeTypeAdd] = useState("");
    const [openModal, setOpen] = useState(false);
    const [profileName, setProfileName] = useState('');
    const [processTypeUpdateId, setCaseTypeUodateId] = useState(0);
    const [errorMessage, setErrorMessage] = useState('');
    const [courtOfficeTypeIdForFilter, setCourtOfficeTypeIdForFilter] = useState(-1);
    const [isActiveForFilter, setIsActiveForFilter] = useState(-1);
    const [isLoading, setIsLoading] = useState(true);
    const [isErrorMessage, setIsErrorMessage] = useState(false);

    const processTypeService = new ProcessTypeService();
    const popupMessageService = new PopupMessageService();
    const authService = new AuthService();

    const catchMessagee = Global.catchMessage;

    //Changing Activity of the current Case Status
    const changeActivity = (cId) => {
        processTypeService.changeActivity2(cId).then(result => {
            getAllProcessTypes()
            popupMessageService.AlertSuccessMessage(result.data.Message);
        }, error => {
            popupMessageService.AlertErrorMessage(error.response.data.Message)
        }).catch(()=> {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    };
    function filtering(processTypes) {
        let filteredCaseTypes = processTypes
        if (courtOfficeTypeIdForFilter > 0)
            filteredCaseTypes = filteredCaseTypes.filter(c => c.CourtOfficeTypeGetDto.CourtOfficeTypeId === courtOfficeTypeIdForFilter)
        if (isActiveForFilter > -1)
            filteredCaseTypes = filteredCaseTypes.filter(c => c.IsActive == isActiveForFilter)
        return filteredCaseTypes
    }
    //List all the Case Statuses of current licence
    const getAllProcessTypes = () => {
            processTypeService.getAll().then(
                (result) => {
                    if (result.data.Success) {
                        setProcessTypes(result.data.Data);
                        setIsLoading(false)
                    }
                },
                (error) => {
                    popupMessageService.AlertErrorMessage(error.response.data.Message);
                }
            ).catch(()=> {
                popupMessageService.AlertErrorMessage(catchMessagee)
            })
    };
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
        getAllProcessTypes();
    }, []);

    const handleChangeStatus = (event) => {
        setStatusForAdd(event.target.value);
    };

    const addNewRecord = () => {
        let obj = {
            ProcessTypeName: profileName,
            isActive: statusForAdd
        }
        let re
        if (processTypeUpdateId > 0) {
            obj.ProcessTypeId = processTypeUpdateId
            re = processTypeService.update(obj)
        }
        else {
            re = processTypeService.add(obj)
        }
        re.then(
            (result) => {
                if (result.data.Success) {
                    getAllProcessTypes()
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
        processTypeService.getById(id).then(result => {
            if (result.data.Success) {
                let caseTypeUpdate = result.data.Data
                setProfileName(caseTypeUpdate.ProcessTypeName)
                setStatusForAdd(caseTypeUpdate.IsActive)
                setCaseTypeUodateId(caseTypeUpdate.ProcessTypeId)
            }
        })
        setOpen(true)
    }
    return (
        <Page title="Process Type | MediLaw">
            <Container>
                <Stack direction="row" alignItems="center" justifyContent="space-between" mb={4}>
                    <Typography variant="h4" gutterBottom>
                        Process Type
                    </Typography>
                    {authService.DoesHaveMandatoryClaim('ProcessTypeAdd') || authService.DoesHaveMandatoryClaim('LicenceOwner') ? (
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
                                        {processTypeUpdateId > 0 ?
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
                                                        label="Process Type Name"
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
                                        {processTypeUpdateId > 0 ?
                                            <Button sx={{top: 5}} size="large" type="submit" variant="contained"
                                                    onClick={() => addNewRecord()}>Edit!</Button>
                                            :
                                            <Button sx={{top: 5}} size="large" type="submit" variant="contained"
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
                <Stack mb={5} ml={8} flexDirection="row" alignItems="center" justifyContent="space-between">
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
                                {processTypes.length > 0 ? (
                                    <TableContainer component={Paper}>
                                        <Table sx={{minWidth: 650}} aria-label="simple table">
                                            <TableHead>
                                                <TableRow sx={{backgroundColor: '#f7f7f7'}}>
                                                    <TableCell sx={{paddingLeft: 7}}>Process Type Name</TableCell>
                                                    <TableCell align="left">Status</TableCell>
                                                    <TableCell align="left">Change Activity</TableCell>
                                                    <TableCell align="left">Edit</TableCell>
                                                    <TableCell align="right"/>
                                                </TableRow>
                                            </TableHead>
                                            <TableBody>
                                                <>
                                                    {
                                                        filtering(processTypes)
                                                            .map((row) => (
                                                                <TableRow
                                                                    key={row.ProcessTypeId}
                                                                    sx={{'&:last-child td, &:last-child th': {border: 0}}}
                                                                >
                                                                    <TableCell component="th" scope="row"
                                                                               sx={{paddingLeft: 7}}>
                                                                        {row.ProcessTypeName}
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
                                                                            onChange={() => changeActivity(row.ProcessTypeId)}
                                                                            inputProps={{'aria-label': 'controlled'}}
                                                                        />
                                                                    </TableCell>
                                                                    <TableCell align="left">
                                                                        <Button
                                                                            variant="contained"
                                                                            onClick={() => openModelForUpdate(row.ProcessTypeId)}
                                                                            sx={{backgroundColor: '#b1b9be'}}
                                                                            startIcon={<Icon icon={roundUpdate}/>}
                                                                        >
                                                                            Edit
                                                                        </Button>
                                                                    </TableCell>
                                                                    <TableCell align="right"/>
                                                                </TableRow>
                                                            ))}
                                                </>
                                            </TableBody>
                                        </Table>
                                    </TableContainer>
                                ) : (
                                    <TableCell sx={{width: '40%'}}>
                                        <img src="/static/illustrations/no.png" alt="login"/>
                                        <Typography variant="h3" gutterBottom textAlign='center' color='#a9a9a9'>No Data
                                            Found!</Typography>
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

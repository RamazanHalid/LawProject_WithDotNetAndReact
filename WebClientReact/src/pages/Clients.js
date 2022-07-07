import {Icon} from '@iconify/react';
import 'react-datepicker/dist/react-datepicker.css';
import plusFill from '@iconify/icons-eva/plus-fill';
// material
import {
    Stack,
    Button,
    Container,
    Typography,
    TextField,
    InputAdornment,
    Box,
    TableContainer,
    Paper,
    Table,
    TableHead,
    TableRow,
    TableCell,
    TableBody,
    Card,
    IconButton,
    Collapse,
    tableCellClasses
} from '@mui/material';
// components
import Page from '../components/Page';
//
import Modal from "@mui/material/Modal";
import CloseIcon from "@material-ui/icons/Close";
import FormControl from "@mui/material/FormControl";
import MenuItem from "@mui/material/MenuItem";
import React, {useEffect, useState} from "react";
import PopupMessageService from "../services/popupMessage.service";
import AuthService from "../services/auth.service";
import {Global} from "../Global";
import Scrollbar from "../components/Scrollbar";
import CircularProgress from "@mui/material/CircularProgress";
import Label from "../components/Label";
import roundUpdate from "@iconify/icons-ic/round-update";
import ToggleOffOutlinedIcon from "@mui/icons-material/ToggleOffOutlined";
import ClientsServise from "../services/clients.servise";
import {sentenceCase} from "change-case";
import Switch from "@mui/material/Switch";
import CountryService from "../services/country.service";
import CityService from "../services/city.service";
import PhoneInTalkOutlinedIcon from "@mui/icons-material/PhoneInTalkOutlined";
import HomeOutlinedIcon from "@mui/icons-material/HomeOutlined";
import DriveFileRenameOutlineOutlinedIcon from '@mui/icons-material/DriveFileRenameOutlineOutlined';
import PublicOutlinedIcon from '@mui/icons-material/PublicOutlined';
import DomainOutlinedIcon from '@mui/icons-material/DomainOutlined';
import AddBusinessOutlinedIcon from '@mui/icons-material/AddBusinessOutlined';
import HomeWorkOutlinedIcon from '@mui/icons-material/HomeWorkOutlined';
import WebOutlinedIcon from '@mui/icons-material/WebOutlined';
import EmailOutlinedIcon from '@mui/icons-material/EmailOutlined';
import KeyboardArrowDownIcon from '@mui/icons-material/KeyboardArrowDown';
import KeyboardArrowUpIcon from '@mui/icons-material/KeyboardArrowUp';
import Alert from "@mui/material/Alert";
import {useNavigate} from "react-router-dom";
// ----------------------------------------------------------------------

export default function Clients() {

    const popupMessageService = new PopupMessageService();
    const authService = new AuthService();
    const catchMessagee = Global.catchMessage;
    const countryService = new CountryService();
    const cityService = new CityService();
    const clientsService = new ClientsServise();
    const [open, setOpen] = React.useState(false);
    const [openModal, setOpenModal] = useState(false);
    const [isLoading, setIsLoading] = useState(true);
    const [countries, setCountries] = useState([]);
    const [cities, setCities] = useState([]);
    const [selectedCountries, setSelectedCountries] = useState(0)
    const [cityIdForAdd, setCityIdForAdd] = useState(0)
    const [customerIdForUpdate, setCustomerIdForUpdate] = useState(0)
    const [isActiveForFilter, setIsActiveForFilter] = useState(-1);
    const [transactionActivityGetAll, setTransactionActivityGetAll] = useState([]);
    const [customerNameForAd, setCustomerNameForAdd] = useState("")
    const [billAddressForAdd, setBillAddressForAdd] = useState("")
    const [taxNoForAdd, setTaxNoForAdd] = useState("")
    const [taxOfficeForAdd, setTaxOfficeForAdd] = useState("")
    const [webSiteForAdd, setWebSiteForAdd] = useState("")
    const [emailForAdd, setEmailForAdd] = useState("")
    const [phoneNumberForAdd, setPhoneNumberForAdd] = useState(0)
    const [isActiveForAdd, setIsActiveForAdd] = useState(false)
    const [time, setTime] = useState(true);
    const [isErrorMessage, setIsErrorMessage] = useState(false);
    const [errorMessage, setErrorMessage] = useState('');
    const navigate = useNavigate();

    function filtering(transactionActivityGetAll) {
        let filterdeTransactionActivities = transactionActivityGetAll
        if (isActiveForFilter > -1)
            filterdeTransactionActivities = filterdeTransactionActivities.filter(c => c.IsActive == isActiveForFilter)
        return filterdeTransactionActivities
    }

    function handleCountryChange(TatId) {
        getAllCities(TatId)
        setSelectedCountries(TatId)
    }

    const handleOpen = () => {
        setCustomerIdForUpdate(0)
        setCustomerNameForAdd("")
        setBillAddressForAdd("")
        setTaxNoForAdd("")
        setTaxOfficeForAdd("")
        setWebSiteForAdd("")
        setEmailForAdd("")
        setPhoneNumberForAdd(0)
        setIsActiveForAdd(true)
        setIsErrorMessage(false)
        setErrorMessage("")
        setOpenModal(true)
    };
    const handleClose = () => {
        setOpenModal(false)
    };

    function getAllCountries() {
        countryService.getAll().then(result => {
                setCountries(result.data.Data)
                setSelectedCountries(result.data.Data[0].CountryId)
                getAllCities(result.data.Data[0].CountryId)
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    }

    function getAllCities(selectedId) {
        cityService.getAll(selectedId).then(result => {
                let id = result.data.Data[0].CityId
                setCityIdForAdd(id)
                setCities(result.data.Data)
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    }

    const getAllClients = () => {
        clientsService.getAll().then(
            (result) => {
                if (result.data.Success) {
                    setTransactionActivityGetAll(result.data.Data)
                    setIsLoading(false)
                }
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    };

    function modalForEdit(id) {
        clientsService.getById(id).then(result => {
            if (result.data.Success) {
                let edit = result.data.Data
                setCustomerIdForUpdate(edit.CustomerId)
                setCustomerNameForAdd(edit.CustomerName)
                setBillAddressForAdd(edit.BillAddress)
                setCityIdForAdd(edit.City.CityId)
                setTaxNoForAdd(edit.TaxNo)
                setTaxOfficeForAdd(edit.TaxOffice)
                setWebSiteForAdd(edit.WebSite)
                setEmailForAdd(edit.Email)
                setPhoneNumberForAdd(edit.PhoneNumber)
                setIsActiveForAdd(edit.IsActive)
            }
        })
        setOpenModal(true)
    }

    function addNewRecord() {
        let obj = {
            customerId: customerIdForUpdate,
            customerName: customerNameForAd,
            billAddress: billAddressForAdd,
            taxNo: taxNoForAdd,
            taxOffice: taxOfficeForAdd,
            webSite: webSiteForAdd,
            email: emailForAdd,
            phoneNumber: phoneNumberForAdd,
            cityId: cityIdForAdd,
            isActive: isActiveForAdd
        }
        let re
        if (customerIdForUpdate > 0) {
            obj.CustomerId = customerIdForUpdate
            re = clientsService.update(obj)
        }
        else {
            re = clientsService.add(obj)
        }
        re.then((result) => {
                if (result.data.Success) {
                    getAllClients()
                    setOpenModal(false)
                    popupMessageService.AlertSuccessMessage(result.data.Message)
                }
            },
            (error) => {
                setIsErrorMessage(true)
                setErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    }
    const changeActivity = (cId) => {
        clientsService.changeActivity2(cId).then(result => {
            getAllClients()
            popupMessageService.AlertSuccessMessage(result.data.Message);
        }, error => {
            popupMessageService.AlertErrorMessage(error.response.data.Message)
        }).catch(()=> {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    };
    useEffect(() => {
        if(authService.DoesHaveMandatoryClaim('CustomerGetAll')||
            authService.DoesHaveMandatoryClaim('LicenceOwner')) {
            getAllCountries()
            getAllCountries()
            getAllClients()
            setTime(false)
        }
        else {
            popupMessageService.AlertErrorMessage("You are not authorized!")
            navigate("/dashboard/app")
        }
    }, []);

    return (
        <Page title="Transaction Activities | MediLaw">
            {time === true ?
                <Stack sx={{color: 'grey.500', padding: 30}} spacing={2} direction="row"
                       justifyContent='center' alignSelf='center' left='50%'>
                    <CircularProgress color="inherit"/>
                </Stack>
                :
                <Container>
                    <Stack direction="row" alignItems="center" justifyContent="space-between" mb={4}>
                        <Typography variant="h4" gutterBottom>
                            Clients
                        </Typography>

                        {authService.DoesHaveMandatoryClaim('CaseTypeAdd') || authService.DoesHaveMandatoryClaim('LicenceOwner') ? (
                            <>
                                <Button onClick={handleOpen} variant="contained" startIcon={<Icon icon={plusFill}/>}>
                                    New Record
                                </Button>
                                <Modal sx={{backgroundColor: "rgba(0, 0, 0, 0.5)"}}
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
                                            width: 700,
                                            backgroundColor: 'background.paper',
                                            border: '2px solid #fff',
                                            p: 4,
                                            borderRadius: 2,
                                        }}
                                    >
                                        <Stack mb={5} flexDirection="row" justifyContent='space-between'>
                                            {customerIdForUpdate > 0 ?
                                                <Typography id="modal-modal-title" variant="h6" component="h2">
                                                    Edit record!
                                                </Typography>
                                                :
                                                <Typography id="modal-modal-title" variant="h6" component="h2">
                                                    Add new record!
                                                </Typography>
                                            }
                                            <IconButton sx={{bottom: 4}}>
                                                <CloseIcon onClick={handleClose}/>
                                            </IconButton>
                                        </Stack>
                                        <Stack spacing={2}>
                                            <Stack mb={0} alignItems="center" justifyContent="space-around">
                                                <Stack mb={3} justifyContent="space-around">
                                                    <Box sx={{minWidth: 630}}>
                                                        <FormControl fullWidth size="small">
                                                            <TextField
                                                                autoFocus
                                                                fullWidth
                                                                size="small"
                                                                label="Customer Name"
                                                                value={customerNameForAd}
                                                                onChange={(event) => setCustomerNameForAdd(event.target.value)}
                                                                InputProps={{
                                                                    startAdornment: (
                                                                        <InputAdornment position="start">
                                                                            <DriveFileRenameOutlineOutlinedIcon/>
                                                                        </InputAdornment>
                                                                    )
                                                                }}
                                                            />
                                                        </FormControl>
                                                    </Box>
                                                </Stack>
                                                <Stack mb={3} direction={{xs: 'column', sm: 'row'}} spacing={2}>
                                                    {countries.length > 0 ? (
                                                        <Box sx={{minWidth: 305}}>
                                                            <FormControl fullWidth size="small">
                                                                <TextField
                                                                    select
                                                                    size='small'
                                                                    label="Country"
                                                                    value={selectedCountries}
                                                                    onChange={(e) => handleCountryChange(e.target.value)}
                                                                    key={Math.random().toString(36).substr(2, 9)}
                                                                    InputProps={{
                                                                        startAdornment: (
                                                                            <InputAdornment position="start">
                                                                                <PublicOutlinedIcon/>
                                                                            </InputAdornment>
                                                                        )
                                                                    }}
                                                                >
                                                                    {countries.map((item) => (
                                                                        <MenuItem
                                                                            key={Math.random().toString(36).substr(2, 9)}
                                                                            value={item.CountryId}
                                                                        >
                                                                            {item.CountryName}
                                                                        </MenuItem>
                                                                    ))}
                                                                </TextField>
                                                            </FormControl>
                                                        </Box>
                                                    ) : null}
                                                {cities.length > 0 ? (
                                                        <Box sx={{minWidth: 305}}>
                                                            <FormControl fullWidth size="small">
                                                                <TextField
                                                                    select
                                                                    size='small'
                                                                    label="City"
                                                                    value={cityIdForAdd}
                                                                    onChange={(e) => setCityIdForAdd(e.target.value)}
                                                                    key={Math.random().toString(36).substr(2, 9)}
                                                                    InputProps={{
                                                                        startAdornment: (
                                                                            <InputAdornment position="start">
                                                                                <DomainOutlinedIcon/>
                                                                            </InputAdornment>
                                                                        )
                                                                    }}
                                                                >
                                                                    {cities.map((item) => (
                                                                        <MenuItem
                                                                            key={Math.random().toString(36).substr(2, 9)}
                                                                            value={item.CityId}
                                                                        >
                                                                            {item.CityName}
                                                                        </MenuItem>
                                                                    ))}
                                                                </TextField>
                                                            </FormControl>
                                                        </Box>
                                                ) : null}
                                                </Stack>
                                                <Stack mb={3} direction={{xs: 'column', sm: 'row'}} spacing={2}>
                                                    <Box sx={{minWidth: 305}}>
                                                        <FormControl fullWidth size="small">
                                                        <TextField
                                                        size="small"
                                                        label="Bill Adress"
                                                        value={billAddressForAdd}
                                                        onChange={(event) => setBillAddressForAdd(event.target.value)}
                                                        InputProps={{
                                                            startAdornment: (
                                                                <InputAdornment position="start">
                                                                    <HomeOutlinedIcon/>
                                                                </InputAdornment>
                                                            )
                                                        }}
                                                    />
                                                        </FormControl>
                                                    </Box>
                                                    <Box sx={{minWidth: 305}}>
                                                        <FormControl fullWidth size="small">
                                                        <TextField
                                                        type="number"
                                                        label="Phone Number"
                                                        size="small"
                                                        value={phoneNumberForAdd}
                                                        onChange={(e) => setPhoneNumberForAdd(e.target.value)}
                                                        InputProps={{
                                                            startAdornment: (
                                                                <InputAdornment position="start">
                                                                    <PhoneInTalkOutlinedIcon/>
                                                                </InputAdornment>
                                                            )
                                                        }}
                                                    />
                                                        </FormControl>
                                                    </Box>
                                                </Stack>
                                                <Stack mb={3} direction={{xs: 'column', sm: 'row'}} spacing={2}>
                                                    <Box sx={{minWidth: 305}}>
                                                        <FormControl fullWidth size="small">
                                                        <TextField
                                                        fullWidth
                                                        size="small"
                                                        label="Tax No"
                                                        value={taxNoForAdd}
                                                        onChange={(event) => setTaxNoForAdd(event.target.value)}
                                                        InputProps={{
                                                            startAdornment: (
                                                                <InputAdornment position="start">
                                                                    <AddBusinessOutlinedIcon/>
                                                                </InputAdornment>
                                                            )
                                                        }}
                                                    />
                                                        </FormControl>
                                                    </Box>
                                                    <Box sx={{minWidth: 305}}>
                                                        <FormControl fullWidth size="small">
                                                        <TextField
                                                        fullWidth
                                                        size="small"
                                                        label="Tax Office"
                                                        value={taxOfficeForAdd}
                                                        onChange={(event) => setTaxOfficeForAdd(event.target.value)}
                                                        InputProps={{
                                                            startAdornment: (
                                                                <InputAdornment position="start">
                                                                    <HomeWorkOutlinedIcon/>
                                                                </InputAdornment>
                                                            )
                                                        }}
                                                    />
                                                        </FormControl>
                                                    </Box>
                                                </Stack>
                                                <Stack mb={3} direction={{xs: 'column', sm: 'row'}} spacing={2}>
                                                    <Box sx={{minWidth: 305}}>
                                                        <FormControl fullWidth size="small">
                                                        <TextField
                                                        fullWidth
                                                        size="small"
                                                        label="Website"
                                                        value={webSiteForAdd}
                                                        onChange={(event) => setWebSiteForAdd(event.target.value)}
                                                        InputProps={{
                                                            startAdornment: (
                                                                <InputAdornment position="start">
                                                                    <WebOutlinedIcon/>
                                                                </InputAdornment>
                                                            )
                                                        }}
                                                    />
                                                        </FormControl>
                                                    </Box>
                                                    <Box sx={{minWidth: 305}}>
                                                        <FormControl fullWidth size="small">
                                                        <TextField
                                                        fullWidth
                                                        type='email'
                                                        size="small"
                                                        label="Email"
                                                        value={emailForAdd}
                                                        onChange={(event) => setEmailForAdd(event.target.value)}
                                                        InputProps={{
                                                            startAdornment: (
                                                                <InputAdornment position="start">
                                                                    <EmailOutlinedIcon/>
                                                                </InputAdornment>
                                                            )
                                                        }}
                                                    />
                                                        </FormControl>
                                                    </Box>
                                                </Stack>
                                            </Stack>
                                            {customerIdForUpdate > 0 ?
                                                <Button sx={{bottom: 7}} size="large" type="submit" variant="contained"
                                                        onClick={() => addNewRecord()}>
                                                    Edit!
                                                </Button>
                                                :
                                                <Button sx={{bottom: 7}} size="large" type="submit" variant="contained"
                                                        onClick={() => addNewRecord()}>
                                                    Add!
                                                </Button>
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
                            <Box sx={{minWidth: 400}}>
                                <FormControl fullWidth size="small">
                                    <TextField
                                        select
                                        size='small'
                                        value={isActiveForFilter}
                                        key={Math.random().toString(36).substr(2, 9)}
                                        label="Status"
                                        onChange={(e) => setIsActiveForFilter(e.target.value)}
                                        InputProps={{
                                            startAdornment: (
                                                <InputAdornment position="start">
                                                    <ToggleOffOutlinedIcon/>
                                                </InputAdornment>
                                            )
                                        }}
                                    >
                                        <MenuItem key={Math.random().toString(36).substr(2, 9)}
                                                  value={-1}>All</MenuItem>
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
                    <Card sx={{marginTop: -3}}>
                        <React.Fragment>
                        <Scrollbar>
                            {isLoading === true ?
                                <Stack sx={{color: 'grey.500', padding: 10}} spacing={2} direction="row"
                                       justifyContent='center'>
                                    <CircularProgress color="inherit"/>
                                </Stack>
                                :
                                <>
                                    {transactionActivityGetAll.length > 0 ? (
                                        <TableContainer component={Paper}>
                                            <Table sx={{minWidth: 650}}  aria-label="collapsible table">
                                                <TableHead>
                                                    <TableRow>
                                                        <TableCell sx={{paddingLeft: 7}}>Customer Full Name</TableCell>
                                                        <TableCell align="left">Phone Number</TableCell>
                                                        <TableCell align="left">Country / City</TableCell>
                                                        <TableCell align="left">Status</TableCell>
                                                        <TableCell align="left">Change Activity</TableCell>
                                                        <TableCell align="left">Edit</TableCell>
                                                        <TableCell align="left">Details</TableCell>
                                                        <TableCell align="right"/>
                                                        <TableCell align="right"/>
                                                    </TableRow>
                                                </TableHead>
                                                <TableBody>
                                                    <>
                                                        {filtering(transactionActivityGetAll).map((row) => (
                                                            <>
                                                            <TableRow
                                                                key={row.CustomerId}
                                                                sx={{'&:last-child td, &:last-child th': {border: 0}}}
                                                            >
                                                                <TableCell component="th" scope="row"
                                                                           sx={{paddingLeft: 7}}>
                                                                    {row.CustomerName}
                                                                </TableCell>
                                                                <TableCell component="th" scope="row">
                                                                    {row.PhoneNumber}
                                                                </TableCell>
                                                                <TableCell component="th" scope="row">
                                                                    {row.City.Country.CountryName} / {row.City.CityName}
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
                                                                        sx={{marginLeft: 2}}
                                                                        checked={row.IsActive}
                                                                        onChange={() => changeActivity(row.CustomerId)}
                                                                        inputProps={{'aria-label': 'controlled'}}
                                                                    />
                                                                </TableCell>
                                                                <TableCell>
                                                                    <Button
                                                                        onClick={() => modalForEdit(row.CustomerId)}
                                                                        variant="contained"
                                                                        sx={{backgroundColor: '#b1b9be'}}
                                                                        startIcon={<Icon icon={roundUpdate}/>}
                                                                    >
                                                                        Edit
                                                                    </Button>
                                                                </TableCell>
                                                                <TableCell>
                                                                    <IconButton
                                                                        sx={{marginLeft: 1}}
                                                                        aria-label="expand row"
                                                                        size="small"
                                                                        onClick={() =>
                                                                            setOpen((prev) => ({ ...prev, [row.CustomerId]: !prev[row.CustomerId] }))
                                                                        }
                                                                    >
                                                                        {open[row.CustomerId] ? <KeyboardArrowUpIcon /> : <KeyboardArrowDownIcon />}
                                                                    </IconButton>
                                                                </TableCell>
                                                                <TableCell align="right"/>
                                                                <TableCell align="right"/>
                                                            </TableRow>
                                                                <TableRow>
                                                                    <TableCell style={{ paddingBottom: 0, paddingTop: 0 }} colSpan={9}>
                                                                        <Collapse in={open[row.CustomerId]}  timeout="auto" unmountOnExit>
                                                                            {open[row.CustomerId] && (
                                                                            <Box sx={{ margin: 1, padding: 1.5 }}>
                                                                                <Table size="small" aria-label="purchases" sx={{[`& .${tableCellClasses.root}`]: {
                                                                                        border: '2px solid #fff', backgroundColor: '#fafafa'}}}>
                                                                                    <TableHead>
                                                                                        <TableRow>
                                                                                            <TableCell component="th" scope="row" align="left">Bill Address</TableCell>
                                                                                            <TableCell align="left">Tax No</TableCell>
                                                                                            <TableCell align="left">Tax Office</TableCell>
                                                                                            <TableCell align="left">Website</TableCell>
                                                                                            <TableCell align="left">Email</TableCell>
                                                                                        </TableRow>
                                                                                    </TableHead>
                                                                                    <TableBody>
                                                                                            <TableRow sx={{[`& .${tableCellClasses.root}`]: {
                                                                                                    borderBottom: "none"}}}>
                                                                                                <TableCell component="th" scope="row">
                                                                                                    {row.BillAddress}
                                                                                                </TableCell>
                                                                                                <TableCell component="th" scope="row">
                                                                                                    {row.TaxNo}
                                                                                                </TableCell>
                                                                                                <TableCell component="th" scope="row">
                                                                                                    {row.TaxOffice}
                                                                                                </TableCell>
                                                                                                <TableCell component="th" scope="row">
                                                                                                    {row.WebSite}
                                                                                                </TableCell>
                                                                                                <TableCell component="th" scope="row">
                                                                                                    {row.Email}
                                                                                                </TableCell>
                                                                                            </TableRow>
                                                                                    </TableBody>
                                                                                </Table>
                                                                            </Box>
                                                                            )}
                                                                        </Collapse>
                                                                    </TableCell>
                                                                </TableRow>
                                                            </>
                                                        ))}
                                                    </>

                                                </TableBody>
                                            </Table>
                                        </TableContainer>
                                    ) : (
                                        <TableCell sx={{width: '40%'}}>
                                            <img src="/static/illustrations/no.png" alt="login"/>
                                            <Typography variant="h3" gutterBottom textAlign='center' color='#a9a9a9'>No
                                                Data Found</Typography>
                                        </TableCell>
                                    )}
                                </>
                            }
                        </Scrollbar>
                        </React.Fragment>
                    </Card>
                </Container>
            }
        </Page>
    );
}

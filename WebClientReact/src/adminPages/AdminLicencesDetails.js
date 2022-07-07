// material
import {styled} from '@mui/material/styles';
import {
    Box,
    Button,
    Card,
    CardContent,
    Container, Divider,
    IconButton,
    Paper,
    Stack, Table, TableBody, TableCell,
    TableContainer, TableHead, TablePagination, TableRow,
    Typography
} from '@mui/material';
// components
import Page from '../components/Page';
import React, {useEffect, useState} from "react";
import {useNavigate, useParams} from "react-router-dom";
import PopupMessageService from "../services/popupMessage.service";
import {Global} from "../Global";
import {Icon} from "@iconify/react";
import arrowBackOutline from "@iconify/icons-eva/arrow-back-outline";
import CircularProgress from "@mui/material/CircularProgress";
import LicencesService from "../services/licences.service";
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import BadgeOutlinedIcon from '@mui/icons-material/BadgeOutlined';
import LocalPhoneOutlinedIcon from '@mui/icons-material/LocalPhoneOutlined';
import EventAvailableOutlinedIcon from '@mui/icons-material/EventAvailableOutlined';
import MapsHomeWorkOutlinedIcon from '@mui/icons-material/MapsHomeWorkOutlined';
import LanguageOutlinedIcon from '@mui/icons-material/LanguageOutlined';
import LocalAtmOutlinedIcon from '@mui/icons-material/LocalAtmOutlined';
import PersonPinOutlinedIcon from '@mui/icons-material/PersonPinOutlined';
import ToggleOffOutlinedIcon from '@mui/icons-material/ToggleOffOutlined';
import {format} from "date-fns";
import Label from "../components/Label";
import {sentenceCase} from "change-case";
import SpeedDial from '@mui/material/SpeedDial';
import SpeedDialIcon from '@mui/material/SpeedDialIcon';
import SpeedDialAction from '@mui/material/SpeedDialAction';
import SmsOutlinedIcon from '@mui/icons-material/SmsOutlined';
import AccountBalanceWalletOutlinedIcon from '@mui/icons-material/AccountBalanceWalletOutlined';
import PeopleAltOutlinedIcon from '@mui/icons-material/PeopleAltOutlined';
import CloseIcon from "@material-ui/icons/Close";
import Modal from "@mui/material/Modal";
import SmsHistoryService from "../services/smsHistory.service";
import PaymentHistoriesService from "../services/paymentHistories.service";
import LicenceUsersService from "../services/licenceUsers.service";
import {tableCellClasses} from "@mui/material/TableCell";
import Scrollbar from "../components/Scrollbar";
import Fab from "@mui/material/Fab";
import ArrowBackIosOutlinedIcon from "@mui/icons-material/ArrowBackIosOutlined";
import ArrowForwardIosOutlinedIcon from "@mui/icons-material/ArrowForwardIosOutlined";
import ChevronLeftOutlinedIcon from "@mui/icons-material/ChevronLeftOutlined";
import ChevronRightOutlinedIcon from "@mui/icons-material/ChevronRightOutlined";
// ----------------------------------------------------------------------

const RootStyle = styled(Page)(({theme}) => ({
    [theme.breakpoints.up('md')]: {
        display: 'flex'
    }
}));

const CustomBox = styled(Page)(({theme}) => ({
    [theme.breakpoints.up('md')]: {
        position: 'absolute',
        top: '50%',
        left: '50%',
        transform: 'translate(-50%, -50%)',
        minWidth: 650,
        maxWidth: 800,
        backgroundColor: '#fff',
        border: '2px solid #fff',
        p: 4,
        borderRadius: 17,
        padding: 40
    }
}));

const StyledTableCell = styled(TableCell)(({theme}) => ({
    [`&.${tableCellClasses.head}`]: {
        backgroundColor: theme.palette.primary.main,
        color: theme.palette.common.white,
    },
    [`&.${tableCellClasses.body}`]: {
        fontSize: 14,
    },
}));

const StyledTableRow = styled(TableRow)(({theme}) => ({
    '&:nth-of-type(odd)': {
        backgroundColor: theme.palette.action.hover,
    },
    // hide last border
    '&:last-child td, &:last-child th': {
        border: 0,
    },
}));
// ----------------------------------------------------------------------

export default function AdminLicencesDetails() {
    const {id} = useParams()
    const popupMessageService = new PopupMessageService();
    const licencesService = new LicencesService();
    const smsHistoryService = new SmsHistoryService();
    const paymentHistoriesService = new PaymentHistoriesService();
    const licenceUsersService = new LicenceUsersService();
    const catchMessagee = Global.catchMessage;
    const [phoneNumber, setPhoneNumber] = useState("")
    const [profilename, setProfileName] = useState("")
    const [taxOffice, setTaxOffice] = useState("")
    const [billAddress, setBillAddress] = useState("")
    const [pageNumber, setPageNumber] = useState(0);
    const [pageSize, setPageSize] = useState(3);
    const [pageNumberForPayment, setPageNumberForPayment] = useState(0);
    const [pageSizeForPayment, setPageSizeForPayment] = useState(4);
    const [pageNumberForUsers, setPageNumberForUsers] = useState(0);
    const [pageSizeForUsers, setPageSizeForUsers] = useState(3);
    const [count, setCount] = useState(10);
    const [smsHistories, setSmsHistories] = useState([])
    const [paymentHistories, setPaymentHistories] = useState([])
    const [registeredUsers, setRegisteredUsers] = useState([])
    const [city, setCity] = useState("")
    const [country, setCountry] = useState("")
    const [balance, setBalance] = useState("")
    const [isActive, setIsActive] = useState(false)
    const [personType, setPersonType] = useState("")
    const [isLoading, setIsLoading] = useState(true);
    const today = new Date();
    const date = today.setDate(today.getDate());
    const defaultValue = new Date(date).toISOString().split('T')[0]
    const [startDate, setStartDate] = useState(defaultValue);
    const [openModalForSmsHistory, setOpenModalForSmsHistory] = useState(false);
    const [openModalForPaymentHistory, setOpenModalForPaymentHistory] = useState(false);
    const [openModalForRegisteredUsers, setOpenModalForRegisteredUsers] = useState(false);
    const navigate = useNavigate();

    const getAllCaseUpdateHistory = (Lid) => {
        licencesService.getByIdAsAdmin(Lid).then(
            (result) => {
                let details = result.data.Data
                setProfileName(details.ProfilName)
                setPhoneNumber(details.PhoneNumber)
                setTaxOffice(details.TaxOffice)
                setStartDate(details.StartDate)
                setBillAddress(details.BillAddress)
                setCity(details.City.CityName)
                setCountry(details.City.Country.CountryName)
                setBalance(details.Balance)
                setPersonType(details.PersonType.PersonTypeName)
                setIsActive(details.IsActive)
                setIsLoading(false)
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    };

    const previousValues = () => {
        if (pageNumber > 0 && smsHistories.length > 0) {
            getAllSmsHistories(pageNumber - 1, pageSize, id)
            setPageNumber(pageNumber - 1)
        }
    }

    const nextValues = () => {
        if (smsHistories.length >= 3) {
            getAllSmsHistories(pageNumber + 1, pageSize, id)
            setPageNumber(pageNumber + 1)
        }
    }

    const previousValuesForPayment = () => {
        if (pageNumberForPayment > 0 && paymentHistories.length > 0) {
            getAllPaymentHistories(pageNumberForPayment - 1, pageSizeForPayment, id)
            setPageNumberForPayment(pageNumberForPayment - 1)
        }
    }

    const nextValuesForPayment = () => {
        if (paymentHistories.length >= 3) {
            getAllPaymentHistories(pageNumberForPayment + 1, pageSizeForPayment, id)
            setPageNumberForPayment(pageNumberForPayment + 1)
        }
    }

    const previousValuesForUsers = () => {
        if (pageNumberForUsers > 0 && registeredUsers.length > 0) {
            getAllRegisteredUsers(pageNumberForUsers - 1, pageSizeForUsers, id)
            setPageNumberForUsers(pageNumberForUsers - 1)
        }
    }

    const nextValuesForUsers = () => {
        if (registeredUsers.length >= 3) {
            getAllRegisteredUsers(pageNumberForUsers + 1, pageSizeForUsers, id)
            setPageNumberForUsers(pageNumberForUsers + 1)
        }
    }

    const handleChangePageForUsers = (event, newPage) => {
        getAllRegisteredUsers(newPage, pageSizeForUsers, id)
        setPageNumberForUsers(newPage);
    };

    const handleChangeRowsPerPageForUsers = (event) => {
        setPageSizeForUsers(event.target.value);
        setPageNumberForUsers(1);
        getAllRegisteredUsers(1, event.target.value, id)
    };


    function getAllSmsHistories(pageNumber, pageSize, licenceId) {
        smsHistoryService.getAllAsAdmin(pageNumber, pageSize, licenceId).then(
            (result) => {
                if (result.data.Success) {
                    setSmsHistories(result.data.Data)
                }
                setOpenModalForSmsHistory(true)
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    }

    function getAllPaymentHistories(pageNumberForPayment, pageSizeForPayment, licenceId) {
        paymentHistoriesService.getAllAsAdmin(pageNumberForPayment, pageSizeForPayment, licenceId).then(
            (result) => {
                if (result.data.Success) {
                    setPaymentHistories(result.data.Data)
                }
                setOpenModalForPaymentHistory(true)
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    }

    function getAllRegisteredUsers(pageNumberForPayment, pageSizeForPayment, licenceId) {
        licenceUsersService.getAllUserRecordToLicence(pageNumberForPayment, pageSizeForPayment, licenceId).then(
            (result) => {
                if (result.data.Success) {
                    setRegisteredUsers(result.data.Data)
                }
                setOpenModalForRegisteredUsers(true)
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    }

    const handleClosModal = () => {
        setOpenModalForSmsHistory(false)
    }

    const handleClosModalForPayment = () => {
        setOpenModalForPaymentHistory(false)
    }

    const handleClosModalForUsers = () => {
        setOpenModalForRegisteredUsers(false)
    }

    useEffect(() => {
        getAllCaseUpdateHistory(id)
    }, [])

    return (
        <RootStyle title="Licence Details | MediLaw">
            <Container>
                <Stack direction="row" alignItems="center" justifyContent="flex-start" mb={4}>
                    <IconButton onClick={() => navigate(-1)} sx={{mr: 3, color: 'text.primary', bottom: 3}}
                                size="large">
                        <Icon icon={arrowBackOutline}/>
                    </IconButton>
                    <Typography variant="h4" gutterBottom>Licence Details</Typography>
                </Stack>
                <Stack flexDirection='row'>
                    {isLoading === true ?
                        <Stack sx={{color: 'grey.500', paddingLeft: 60, paddingTop: 25}} spacing={2}
                               direction="row"
                               justifyContent='center' alignSelf='center' left='50%'>
                            <CircularProgress color="inherit"/>
                        </Stack>
                        :
                        <>
                            <Card sx={{
                                width: '100%',
                                maxWidth: 840,
                                bgcolor: 'background.paper',
                                marginLeft: 10,
                                marginTop: 3
                            }}>
                                <List
                                    sx={{
                                        width: '100%',
                                        maxWidth: 830,
                                        bgcolor: 'background.paper',
                                        marginLeft: 0.5,
                                        padding: 2
                                    }}>
                                    <ListItem sx={{
                                        backgroundColor: '#f7f7f7',
                                        padding: 2,
                                        border: '6px solid #fff',
                                    }}>
                                        <ListItemIcon>
                                            <BadgeOutlinedIcon/>
                                        </ListItemIcon>
                                        <ListItemText id="switch-list-label-wifi" primary="Profile Name :"/>
                                        <Typography
                                            sx={{display: 'inline'}}
                                            component="span"
                                            variant="body1"
                                            color="text.primary"
                                        >
                                            {profilename}
                                        </Typography>
                                    </ListItem>
                                    <ListItem sx={{paddingLeft: 2.7}}>
                                        <ListItemIcon>
                                            <LocalPhoneOutlinedIcon/>
                                        </ListItemIcon>
                                        <ListItemText id="switch-list-label-bluetooth" primary="Phone Number :"/>
                                        <Typography
                                            sx={{display: 'inline'}}
                                            component="span"
                                            variant="body1"
                                            color="text.primary"
                                        >
                                            {phoneNumber}
                                        </Typography>
                                    </ListItem>
                                    <ListItem sx={{
                                        backgroundColor: '#f7f7f7',
                                        padding: 2,
                                        border: '6px solid #fff',
                                    }}>
                                        <ListItemIcon>
                                            <EventAvailableOutlinedIcon/>
                                        </ListItemIcon>
                                        <ListItemText id="switch-list-label-wifi" primary="Start Date :"/>
                                        <Typography
                                            sx={{display: 'inline'}}
                                            component="span"
                                            variant="body1"
                                            color="text.primary"
                                        >
                                            {format(new Date(startDate), 'dd/MM/yyyy')}
                                        </Typography>
                                    </ListItem>
                                    <ListItem sx={{paddingLeft: 2.7}}>
                                        <ListItemIcon>
                                            <MapsHomeWorkOutlinedIcon/>
                                        </ListItemIcon>
                                        <ListItemText id="switch-list-label-bluetooth" primary="Tax Office :"/>
                                        <Typography
                                            sx={{display: 'inline'}}
                                            component="span"
                                            variant="body1"
                                            color="text.primary"
                                        >
                                            {taxOffice}
                                        </Typography>
                                    </ListItem>
                                    <ListItem sx={{
                                        backgroundColor: '#f7f7f7',
                                        padding: 2,
                                        border: '6px solid #fff',
                                    }}>
                                        <ListItemIcon>
                                            <LanguageOutlinedIcon/>
                                        </ListItemIcon>
                                        <ListItemText id="switch-list-label-bluetooth" primary="Country / City :"/>
                                        <Typography
                                            sx={{display: 'inline'}}
                                            component="span"
                                            variant="body1"
                                            color="text.primary"
                                        >
                                            {country} / {city}
                                        </Typography>
                                    </ListItem>
                                    <ListItem sx={{paddingLeft: 2.7}}>
                                        <ListItemIcon>
                                            <LocalAtmOutlinedIcon/>
                                        </ListItemIcon>
                                        <ListItemText id="switch-list-label-wifi" primary="Balance :"/>
                                        <Typography
                                            sx={{display: 'inline'}}
                                            component="span"
                                            variant="body1"
                                            color="text.primary"
                                        >
                                            ${balance}
                                        </Typography>
                                    </ListItem>
                                    <ListItem sx={{
                                        backgroundColor: '#f7f7f7',
                                        padding: 2,
                                        border: '6px solid #fff',
                                    }}>
                                        <ListItemIcon>
                                            <PersonPinOutlinedIcon/>
                                        </ListItemIcon>
                                        <ListItemText id="switch-list-label-bluetooth" primary="Person Type :"/>
                                        <Typography
                                            sx={{display: 'inline'}}
                                            component="span"
                                            variant="body1"
                                            color="text.primary"
                                        >
                                            {personType}
                                        </Typography>
                                    </ListItem>
                                    <ListItem sx={{paddingLeft: 2.7}}>
                                        <ListItemIcon>
                                            <ToggleOffOutlinedIcon/>
                                        </ListItemIcon>
                                        <ListItemText id="switch-list-label-wifi" primary="Status :"/>
                                        {isActive ? (
                                            <Label variant="ghost" color="success" sx={{fontSize: 13}}>
                                                {sentenceCase('Active')}
                                            </Label>
                                        ) : (
                                            <Label variant="ghost" color="error" sx={{fontSize: 13}}>
                                                {sentenceCase('Passive')}
                                            </Label>
                                        )}
                                    </ListItem>
                                </List>
                            </Card>
                        </>
                    }
                    <Box sx={{height: 320, transform: 'translateX(0px)', flexGrow: 1, marginRight: 4, marginTop: -18}}>
                        <SpeedDial
                            direction='down'
                            ariaLabel="SpeedDial basic example"
                            sx={{position: 'absolute', bottom: 16, right: 0}}
                            icon={<SpeedDialIcon/>}
                        >
                            <SpeedDialAction
                                key={Math.random().toString(36).substr(2, 9)}
                                icon={<SmsOutlinedIcon/>}
                                tooltipTitle='SMS History'
                                onClick={(e) => {
                                    getAllSmsHistories(pageNumber, pageSize, id, e)
                                }}
                            />
                            <SpeedDialAction
                                key={Math.random().toString(36).substr(2, 9)}
                                icon={<AccountBalanceWalletOutlinedIcon/>}
                                tooltipTitle='Payment History'
                                onClick={(e) => {
                                    getAllPaymentHistories(pageNumberForPayment, pageSizeForPayment, id, e)
                                }}
                            />
                            <SpeedDialAction
                                key={Math.random().toString(36).substr(2, 9)}
                                icon={<PeopleAltOutlinedIcon/>}
                                tooltipTitle='Registered Users'
                                onClick={(e) => {
                                    getAllRegisteredUsers(pageNumberForUsers, pageSizeForUsers, id, e)
                                }}
                            />
                        </SpeedDial>
                    </Box>
                </Stack>
                <Modal sx={{backgroundColor: "rgba(0, 0, 0, 0.3)"}}
                       hideBackdrop={true}
                       disableEscapeKeyDown={true}
                       open={openModalForSmsHistory}
                >
                    <CustomBox>
                        <Stack mb={2} flexDirection="row"
                               justifyContent='space-between'>
                            <Typography id="modal-modal-title"
                                        variant="h6" component="h2">
                                SMS History!
                            </Typography>
                            <IconButton sx={{bottom: 4}}>
                                <CloseIcon onClick={handleClosModal}/>
                            </IconButton>
                        </Stack>
                        <Stack sx={{minWidth: 650}}>
                            <Scrollbar>
                                {smsHistories.length > 0 ? (
                                    <TableContainer component={Paper}>
                                        <Table sx={{minWidth: 650}} aria-label="simple table">
                                            <TableHead>
                                                <TableRow sx={{backgroundColor: '#f7f7f7'}}>
                                                    <StyledTableCell sx={{paddingLeft: 5}}>Recipient
                                                        Name</StyledTableCell>
                                                    <StyledTableCell align="left">Recipient Role</StyledTableCell>
                                                    <StyledTableCell align="left">Date</StyledTableCell>
                                                    <StyledTableCell align="left">Phone Number</StyledTableCell>
                                                    <StyledTableCell align="right"/>
                                                </TableRow>
                                            </TableHead>
                                            <TableBody>
                                                <>
                                                    {smsHistories.map((row) => (
                                                        <StyledTableRow
                                                            key={row.SmsHistoryId}
                                                            sx={{'&:last-child td, &:last-child th': {border: 0}}}>
                                                            <StyledTableCell component="th" scope="row"
                                                                             sx={{paddingLeft: 5}}>
                                                                {row.RecipientName}
                                                            </StyledTableCell>
                                                            <StyledTableCell component="th" scope="row">
                                                                {row.RecipientRole}
                                                            </StyledTableCell>
                                                            <StyledTableCell component="th" scope="row">
                                                                {format(new Date(row.Date), 'dd/MM/yyyy')}
                                                            </StyledTableCell>
                                                            <StyledTableCell component="th" scope="row">
                                                                {row.PhoneNumber}
                                                            </StyledTableCell>
                                                            <TableCell align="right"/>
                                                        </StyledTableRow>
                                                    ))}
                                                </>
                                            </TableBody>
                                        </Table>
                                        <Stack direction="row" alignItems="center" justifyContent="space-between" marginLeft={65}>
                                            <Box sx={{display: 'flex', alignItems: 'center', marginRight:3}}>
                                                <Box sx={{m: 0, position: 'relative'}}>
                                                    <IconButton onClick={previousValues}>
                                                        <ChevronLeftOutlinedIcon sx={{width: 27, height: 27}}/>
                                                    </IconButton>
                                                </Box>
                                                <Box sx={{m: 0, position: 'relative', marginLeft: 0.5}}>
                                                    <IconButton onClick={nextValues}>
                                                        <ChevronRightOutlinedIcon sx={{width: 27, height: 27}}/>
                                                    </IconButton>
                                                </Box>
                                            </Box>
                                        </Stack>
                                    </TableContainer>
                                ) : (
                                    <Box>
                                        <img src="/static/illustrations/no.png" alt="login"/>
                                        <Typography variant="h3" gutterBottom textAlign='center' color='#a9a9a9'>No Data
                                            Found</Typography>
                                    </Box>
                                )}
                            </Scrollbar>
                        </Stack>
                    </CustomBox>
                </Modal>
                <Modal sx={{backgroundColor: "rgba(0, 0, 0, 0.3)"}}
                       hideBackdrop={true}
                       disableEscapeKeyDown={true}
                       open={openModalForPaymentHistory}
                >
                    <CustomBox>
                        <Stack mb={2} flexDirection="row"
                               justifyContent='space-between'>
                            <Typography id="modal-modal-title"
                                        variant="h6" component="h2">
                                Payment History!
                            </Typography>
                            <IconButton sx={{bottom: 4}}>
                                <CloseIcon onClick={handleClosModalForPayment}/>
                            </IconButton>
                        </Stack>
                        <Stack sx={{minWidth: 300}}>
                            <Scrollbar>
                                {paymentHistories.length > 0 ? (
                                    <TableContainer component={Paper} sx={{maxHeight: 350}}>
                                        <Table sx={{minWidth: 450}} aria-label="simple table">
                                            <TableHead>
                                                <TableRow sx={{backgroundColor: '#f7f7f7'}}>
                                                    <StyledTableCell sx={{paddingLeft: 5}}>Profile
                                                        Name</StyledTableCell>
                                                    <StyledTableCell align="left">Payment Date</StyledTableCell>
                                                    <StyledTableCell align="left">Balance</StyledTableCell>
                                                    <StyledTableCell align="right"/>
                                                </TableRow>
                                            </TableHead>
                                            <TableBody>
                                                <>
                                                    {paymentHistories.map((row) => (
                                                        <StyledTableRow
                                                            key={row.Id}
                                                            sx={{'&:last-child td, &:last-child th': {border: 0}}}>
                                                            <StyledTableCell component="th" scope="row"
                                                                             sx={{paddingLeft: 5}}>
                                                                {row.LicenceProfileName}
                                                            </StyledTableCell>
                                                            <StyledTableCell component="th" scope="row">
                                                                {format(new Date(row.PaymentDate), 'dd/MM/yyyy')}
                                                            </StyledTableCell>
                                                            <StyledTableCell component="th" scope="row">
                                                                {row.Balance}
                                                            </StyledTableCell>
                                                            <TableCell align="right"/>
                                                        </StyledTableRow>
                                                    ))}
                                                </>
                                            </TableBody>
                                        </Table>
                                        <Stack direction="row" alignItems="center" justifyContent="space-between" marginLeft={56}>
                                            <Box sx={{display: 'flex', alignItems: 'center', marginRight:2}}>
                                                <Box sx={{m: 0, position: 'relative'}}>
                                                    <IconButton onClick={previousValuesForPayment}>
                                                        <ChevronLeftOutlinedIcon sx={{width: 27, height: 27}}/>
                                                    </IconButton>
                                                </Box>
                                                <Box sx={{m: 0, position: 'relative', marginLeft: 0.5}}>
                                                    <IconButton onClick={nextValuesForPayment}>
                                                        <ChevronRightOutlinedIcon sx={{width: 27, height: 27}}/>
                                                    </IconButton>
                                                </Box>
                                            </Box>
                                        </Stack>
                                    </TableContainer>
                                ) : (
                                    <Box>
                                        <img src="/static/illustrations/no.png" alt="login"/>
                                        <Typography variant="h3" gutterBottom textAlign='center' color='#a9a9a9'>No Data
                                            Found</Typography>
                                    </Box>
                                )}
                            </Scrollbar>
                        </Stack>
                    </CustomBox>
                </Modal>
                <Modal sx={{backgroundColor: "rgba(0, 0, 0, 0.3)"}}
                       hideBackdrop={true}
                       disableEscapeKeyDown={true}
                       open={openModalForRegisteredUsers}
                >
                    <CustomBox>
                        <Stack mb={2} flexDirection="row"
                               justifyContent='space-between'>
                            <Typography id="modal-modal-title"
                                        variant="h6" component="h2">
                                Registered Users!
                            </Typography>
                            <IconButton sx={{bottom: 4}}>
                                <CloseIcon onClick={handleClosModalForUsers}/>
                            </IconButton>
                        </Stack>
                        <Stack sx={{minWidth: 720}}>
                            <Scrollbar>
                                {registeredUsers.length > 0 ? (
                                    <TableContainer component={Paper}>
                                        <Table sx={{minWidth: 650}} aria-label="simple table">
                                            <TableHead>
                                                <TableRow sx={{backgroundColor: '#f7f7f7'}}>
                                                    <StyledTableCell sx={{paddingLeft: 4}}>Title</StyledTableCell>
                                                    <StyledTableCell align="left">Full Name</StyledTableCell>
                                                    <StyledTableCell align="left">Cell Phone</StyledTableCell>
                                                    <StyledTableCell align="left">Email</StyledTableCell>
                                                    <StyledTableCell align="left">StartDate</StyledTableCell>
                                                    <StyledTableCell align="right"/>
                                                </TableRow>
                                            </TableHead>
                                            <TableBody>
                                                <>
                                                    {registeredUsers.map((row) => (
                                                        <StyledTableRow
                                                            key={row.UserId}
                                                            sx={{'&:last-child td, &:last-child th': {border: 0}}}>
                                                            <StyledTableCell component="th" scope="row"
                                                                             sx={{paddingLeft: 4}}>
                                                                {row.Title}
                                                            </StyledTableCell>
                                                            <StyledTableCell component="th" scope="row">
                                                                {row.FirstName} {row.LastName}
                                                            </StyledTableCell>
                                                            <StyledTableCell component="th" scope="row">
                                                                {row.CellPhone}
                                                            </StyledTableCell>
                                                            <StyledTableCell component="th" scope="row">
                                                                {row.Email}
                                                            </StyledTableCell>
                                                            <StyledTableCell component="th" scope="row">
                                                                {format(new Date(row.AddedDateToLicence), 'dd/MM/yyyy')}
                                                            </StyledTableCell>
                                                            <TableCell align="right"/>
                                                        </StyledTableRow>
                                                    ))}
                                                </>
                                            </TableBody>
                                        </Table>
                                        <Stack direction="row" alignItems="center" justifyContent="space-between" marginLeft={75}>
                                            <Box sx={{display: 'flex', alignItems: 'center', marginRight:3}}>
                                                <Box sx={{m: 0, position: 'relative'}}>
                                                    <IconButton onClick={previousValuesForUsers}>
                                                        <ChevronLeftOutlinedIcon sx={{width: 27, height: 27}}/>
                                                    </IconButton>
                                                </Box>
                                                <Box sx={{m: 0, position: 'relative', marginLeft: 0.5}}>
                                                    <IconButton onClick={nextValuesForUsers}>
                                                        <ChevronRightOutlinedIcon sx={{width: 27, height: 27}}/>
                                                    </IconButton>
                                                </Box>
                                            </Box>
                                        </Stack>
                                    </TableContainer>
                                ) : (
                                    <Box>
                                        <img src="/static/illustrations/no.png" alt="login"/>
                                        <Typography variant="h3" gutterBottom textAlign='center' color='#a9a9a9'>No Data
                                            Found</Typography>
                                    </Box>
                                )}
                            </Scrollbar>
                        </Stack>
                    </CustomBox>
                </Modal>
            </Container>
        </RootStyle>
    );
}
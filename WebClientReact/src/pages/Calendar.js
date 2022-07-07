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
    InputAdornment, Box, TableContainer, Paper, Table, TableRow, TableCell, Card, Grid, Divider, IconButton, Link
} from '@mui/material';
// components
import Page from '../components/Page';
import DnsOutlinedIcon from '@mui/icons-material/DnsOutlined';
import Modal from "@mui/material/Modal";
import CloseIcon from "@material-ui/icons/Close";
import FormControl from "@mui/material/FormControl";
import MenuItem from "@mui/material/MenuItem";
import React, {useEffect, useState} from "react";
import PopupMessageService from "../services/popupMessage.service";
import AuthService from "../services/auth.service";
import {Global} from "../Global";
import BusinessCenterOutlinedIcon from '@mui/icons-material/BusinessCenterOutlined';
import TodayOutlinedIcon from '@mui/icons-material/TodayOutlined';
import InsertInvitationOutlinedIcon from '@mui/icons-material/InsertInvitationOutlined';
import ToggleOffOutlinedIcon from '@mui/icons-material/ToggleOffOutlined';
import CircularProgress from "@mui/material/CircularProgress";
import roundUpdate from "@iconify/icons-ic/round-update";
import ClientsServise from "../services/clients.servise";
import CasesService from "../services/cases.service";
import SubtitlesOutlinedIcon from '@mui/icons-material/SubtitlesOutlined';
import layersOutline from "@iconify/icons-eva/layers-outline";
import TasksService from "../services/tasks.service";
import LicenceUsersService from "../services/licenceUsers.service";
import {format} from "date-fns";
import EventsService from "../services/events.service";
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import EventTypesService from "../services/eventTypes.service";
import DateRangeOutlinedIcon from '@mui/icons-material/DateRangeOutlined';
import PersonOutlineOutlinedIcon from '@mui/icons-material/PersonOutlineOutlined';
import PeopleAltOutlinedIcon from '@mui/icons-material/PeopleAltOutlined';
import Label from "../components/Label";
import moment from "moment";
import {styled} from "@mui/material/styles";
import Alert from "@mui/material/Alert";
import {useNavigate} from "react-router-dom";
// ----------------------------------------------------------------------

const AccountStyle = styled('div')(({ theme }) => ({
    display: 'flex',
    alignItems: 'center',
    padding: theme.spacing(2, 2.5),
    borderRadius: theme.shape.borderRadius,
    width: 110,
    height:47
}));

export default function Calendar() {

    const today = new Date();
    const date = today.setDate(today.getDate());
    const defaultValue = new Date(date).toISOString().split('T')[0]
    const popupMessageService = new PopupMessageService();
    const authService = new AuthService();
    const clientsServise = new ClientsServise();
    const eventsService = new EventsService();
    const licenceUsersService = new LicenceUsersService();
    const catchMessagee = Global.catchMessage;
    const tasksService = new TasksService();
    const eventTypesService = new EventTypesService();
    const casesService = new CasesService();
    const [openModal, setOpenModal] = useState(false);
    const [isLoading, setIsLoading] = useState(true);
    const [time, setTime] = useState(true);
    const [openModalForDetails, setOpenModalForDetails] = useState(false);

    const [tasks, setTasks] = useState([]);
    const [eventId, setEventId] = useState(0);
    const [allUsers, setAllUsers] = useState([]);
    const [allEvents, setAllEventTypes] = useState([]);
    const navigate = useNavigate();
    const [eventTypeIdForAdd, setEventTypeIdForAdd] = useState(0)
    const [customerIdForAdd, setCustomerIdForAdd] = useState(0)
    const [caseeIdForAdd, setCaseeIdForAdd] = useState(0)
    const [startDateForAdd, setstartDateForAdd] = useState(defaultValue)
    const [endDateForAdd, setEndDateForAdd] = useState(defaultValue)
    const [userIdForAdd, setUserIdForAdd] = useState(0)
    const [infoForAdd, setInfoForAdd] = useState("")
    const [isActiveForAdd, setIsActiveForAdd] = useState(false)
    const [allClients, setAllClients] = useState([])
    const [allCases, setAllases] = useState([]);
    const [eventTypeName, setEventTypeName] = useState("")
    const [clientName, setCllientName] = useState("")
    const [caseNo, setCaseNo] = useState("")
    const [userName, setUserName] = useState("")
    const [titleForAdd, setTitleForAdd] = useState("")
    const [isErrorMessage, setIsErrorMessage] = useState(false);
    const [errorMessage, setErrorMessage] = useState('');

    const days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
    const monthNames = ["January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"
    ];

    // List all Event Types
    const getAllEventTypes = () => {
        eventTypesService
            .getAll()
            .then(
                (response) => {
                    setAllEventTypes(response.data.Data);
                    const CaseTypesFromApi = response.data.Data;
                    const list = [];
                    CaseTypesFromApi.forEach((item) => {
                        list.push({
                            value: item.EventTypeId,
                            label: item.EventTypeName,
                            key: item.EventTypeName
                        });
                    });
                    if(list.length > 0) {
                        setEventTypeIdForAdd(list[0].value)
                    }
                    setAllEventTypes(list);
                },
                (error) => {
                    popupMessageService.AlertErrorMessage(error.response.data.Message);
                }
            )
            .catch(() => {
                popupMessageService.AlertErrorMessage(catchMessagee)
            });
    };

    // List all Cases
    const getAllCases = () => {
        casesService
            .getAll()
            .then(
                (response) => {
                    setAllases(response.data.Data);
                    const CaseTypesFromApi = response.data.Data;
                    const list = [];
                    CaseTypesFromApi.forEach((item) => {
                        list.push({
                            value: item.CaseeId,
                            label: item.CaseNo,
                            key: item.CaseNo
                        });
                    });
                    if(list.length > 0) {
                        setCaseeIdForAdd(list[0].value)
                    }
                    setAllases(list);
                },
                (error) => {
                    popupMessageService.AlertErrorMessage(error.response.data.Message);
                }
            )
            .catch(() => {
                popupMessageService.AlertErrorMessage(catchMessagee)
            });
    };

    // List all Users
    const getAllUsers = () => {
        licenceUsersService
            .getAll()
            .then(
                (response) => {
                    setAllUsers(response.data.Data);
                    const CaseTypesFromApi = response.data.Data;
                    const list = [];
                    CaseTypesFromApi.forEach((item) => {
                        list.push({
                            value: item.User.Id,
                            label: item.User.Title,
                            key: item.User.Title
                        });
                    });
                    if(list.length > 0) {
                        setUserIdForAdd(list[0].value)
                    }
                    setAllUsers(list);
                },
                (error) => {
                    popupMessageService.AlertErrorMessage(error.response.data.Message);
                }
            )
            .catch(() => {
                popupMessageService.AlertErrorMessage(catchMessagee)
            });
    };

    // List all clients
    const getAllCustomers = () => {
        clientsServise
            .getAll()
            .then(
                (response) => {
                    setAllClients(response.data.Data);
                    const CaseTypesFromApi = response.data.Data;
                    const list = [];
                    CaseTypesFromApi.forEach((item) => {
                        list.push({
                            value: item.CustomerId,
                            label: item.CustomerName,
                            key: item.CustomerName
                        });
                    });
                    if(list.length > 0) {
                        setCustomerIdForAdd(list[0].value)
                    }
                    setAllClients(list);
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

    const handleChangeStatus = (event) => {
        setIsActiveForAdd(event.target.value);
    };

    const handleOpen = () => {
        setEventId(0)
        setInfoForAdd("")
        setTitleForAdd("")
        setstartDateForAdd(defaultValue)
        setEndDateForAdd(defaultValue)
        setIsErrorMessage(false)
        setErrorMessage("")
        setOpenModal(true)
    };
    const handleClose = () => {
        setOpenModal(false)
    };
    const getAllEvents = () => {
        eventsService.getAll().then(
            (result) => {
                if (result.data.Success) {
                    setTasks(result.data.Data)
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
        eventsService.getById(id).then(result => {
            if (result.data.Success) {
                let edit = result.data.Data
                setEventId(edit.EventtId)
                setTitleForAdd(edit.Title)
                setInfoForAdd(edit.Info)
                setUserIdForAdd(edit.User.Id)
                setIsActiveForAdd(edit.IsActive)
                setEventTypeIdForAdd(edit.EventType.EventTypeId)
                setCustomerIdForAdd(edit.Customer.CustomerId)
                setCaseeIdForAdd(edit.Casee.CaseeId)
                setstartDateForAdd(moment(edit.StartDate.getDate()).format('dd/MM/yyyy'))
                setEndDateForAdd(moment(edit.EndDate.getDate()).format('DD/MM/YYYY'))
            }
        })
        setOpenModal(true)
    }

    function getByIdTasks(id) {
        eventsService.getById(id).then(result => {
            if (result.data.Success) {
                let edit = result.data.Data
                setEventTypeName(edit.EventType.EventTypeName)
                setCllientName(edit.Customer.CustomerName)
                setCaseNo(edit.Casee.CaseNo)
                setUserName(edit.User.Title)
                setInfoForAdd(edit.Info)
                setTitleForAdd(edit.Title)
                setstartDateForAdd(edit.StartDate)
                setEndDateForAdd(edit.EndDate)
            }
        })
        setOpenModalForDetails(true)
    }

    const handleClosModal = () => {
        setOpenModalForDetails(false)
    }

    function addNewRecord() {
        let obj = {
            eventTypeId: eventTypeIdForAdd,
            customerId: customerIdForAdd,
            caseeId: caseeIdForAdd,
            startDate: new Date(startDateForAdd),
            endDate: new Date(endDateForAdd),
            userId: userIdForAdd,
            info: infoForAdd,
            title: titleForAdd,
            isActive: isActiveForAdd
        }
        let re
        if (eventId > 0) {
            obj.EventtId = eventId
            re = eventsService.update(obj)
        } else {
            re = eventsService.add(obj)
        }
        re.then((result) => {
                if (result.data.Success) {
                    getAllEvents()
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

    useEffect(() => {
    if(authService.DoesHaveMandatoryClaim('EventtGetAll')||
        authService.DoesHaveMandatoryClaim('LicenceOwner')) {
        getAllUsers()
        getAllCases()
        getAllCustomers()
        getAllEvents()
        getAllEventTypes()
        setTime(false)
    }
    else {
        popupMessageService.AlertErrorMessage("You are not authorized!")
        navigate("/dashboard/app")
    }
    }, []);

    return (
        <Page title="Events | MediLaw">
            {time === true ?
                <Stack sx={{color: 'grey.500', padding: 30}} spacing={2} direction="row"
                       justifyContent='center' alignSelf='center' left='50%'>
                    <CircularProgress color="inherit"/>
                </Stack>
                :
                <Container>
                    <Stack direction="row" alignItems="center" justifyContent="space-between" mb={4}>
                        <Typography variant="h4" gutterBottom>
                            Events
                        </Typography>
                        {authService.DoesHaveMandatoryClaim('EventtAdd') || authService.DoesHaveMandatoryClaim('LicenceOwner') ? (
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
                                    <Box sx={{
                                        position: 'absolute',
                                        top: '50%',
                                        left: '50%',
                                        transform: 'translate(-50%, -50%)',
                                        width: 700,
                                        backgroundColor: 'background.paper',
                                        border: '2px solid #fff',
                                        p: 4,
                                        borderRadius: 2
                                    }}>
                                        <Stack mb={5} flexDirection="row" justifyContent='space-between'>
                                            {eventId > 0 ?
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
                                                <Stack mb={3} direction={{xs: 'column', sm: 'row'}} spacing={2}>
                                                    <Box sx={{maxWidth: 305, minWidth: 305}}>
                                                        <TextField
                                                            autoFocus
                                                            fullWidth
                                                            size='small'
                                                            label="Title"
                                                            value={titleForAdd}
                                                            onChange={(e) => setTitleForAdd(e.target.value)}
                                                            InputProps={{
                                                                startAdornment: (
                                                                    <InputAdornment position="start">
                                                                        <SubtitlesOutlinedIcon/>
                                                                    </InputAdornment>
                                                                )
                                                            }}
                                                        />
                                                    </Box>
                                                    {allEvents.length > 0 ? (
                                                        <Box sx={{maxWidth: 305, minWidth: 305}}>
                                                            <FormControl fullWidth size="small">
                                                                <TextField
                                                                    select
                                                                    size='small'
                                                                    label="Event Types"
                                                                    value={eventTypeIdForAdd}
                                                                    onChange={(e) => setEventTypeIdForAdd(e.target.value)}
                                                                    key={Math.random().toString(36).substr(2, 9)}
                                                                    InputProps={{
                                                                        startAdornment: (
                                                                            <InputAdornment position="start">
                                                                                <DateRangeOutlinedIcon/>
                                                                            </InputAdornment>
                                                                        )
                                                                    }}
                                                                >
                                                                    {allEvents.map((item) => (
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
                                                <Stack mb={3} direction={{xs: 'column', sm: 'row'}} spacing={2}>
                                                    {allClients.length > 0 ? (
                                                        <Box sx={{maxWidth: 305, minWidth: 305}}>
                                                            <FormControl fullWidth size="small">
                                                                <TextField
                                                                    select
                                                                    size='small'
                                                                    label="Clients"
                                                                    value={customerIdForAdd}
                                                                    onChange={(e) => setCustomerIdForAdd(e.target.value)}
                                                                    key={Math.random().toString(36).substr(2, 9)}
                                                                    InputProps={{
                                                                        startAdornment: (
                                                                            <InputAdornment position="start">
                                                                                <PersonOutlineOutlinedIcon/>
                                                                            </InputAdornment>
                                                                        )
                                                                    }}
                                                                >
                                                                    {allClients.map((item) => (
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
                                                    {allCases.length > 0 ? (
                                                        <Box sx={{maxWidth: 305, minWidth: 305}}>
                                                            <FormControl fullWidth size="small">
                                                                <TextField
                                                                    select
                                                                    size='small'
                                                                    label="Cases"
                                                                    value={caseeIdForAdd}
                                                                    onChange={(e) => setCaseeIdForAdd(e.target.value)}
                                                                    key={Math.random().toString(36).substr(2, 9)}
                                                                    InputProps={{
                                                                        startAdornment: (
                                                                            <InputAdornment position="start">
                                                                                <BusinessCenterOutlinedIcon/>
                                                                            </InputAdornment>
                                                                        )
                                                                    }}
                                                                >
                                                                    {allCases.map((item) => (
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
                                                <Stack mb={3} direction={{xs: 'column', sm: 'row'}} spacing={2}>
                                                    {allUsers.length > 0 ? (
                                                        <Box sx={{maxWidth: 305, minWidth: 305}}>
                                                            <FormControl fullWidth size="small">
                                                                <TextField
                                                                    select
                                                                    size='small'
                                                                    label="users"
                                                                    value={userIdForAdd}
                                                                    onChange={(e) => setUserIdForAdd(e.target.value)}
                                                                    key={Math.random().toString(36).substr(2, 9)}
                                                                    InputProps={{
                                                                        startAdornment: (
                                                                            <InputAdornment position="start">
                                                                                <PeopleAltOutlinedIcon/>
                                                                            </InputAdornment>
                                                                        )
                                                                    }}
                                                                >
                                                                    {allUsers.map((item) => (
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
                                                    <Box sx={{maxWidth: 305, minWidth: 305}}>
                                                        <FormControl fullWidth size="small">
                                                            <TextField
                                                                select
                                                                size='small'
                                                                labelId="demo-simple-select-label"
                                                                id="demo-simple-select"
                                                                value={isActiveForAdd}
                                                                key={createRandomKey}
                                                                label="Status"
                                                                onChange={handleChangeStatus}
                                                                InputProps={{
                                                                    startAdornment: (
                                                                        <InputAdornment position="start">
                                                                            <ToggleOffOutlinedIcon/>
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
                                                <Stack mb={3} direction={{xs: 'column', sm: 'row'}} spacing={2}>
                                                    <Box sx={{maxWidth: 305, minWidth: 305}}>
                                                        <FormControl fullWidth size="small">
                                                            <TextField
                                                                id="date"
                                                                label="Start Date"
                                                                type="date"
                                                                size="small"
                                                                value={startDateForAdd}
                                                                onChange={(e) => setstartDateForAdd(e.target.value)}
                                                                InputProps={{
                                                                    startAdornment: (
                                                                        <InputAdornment position="start">
                                                                            <TodayOutlinedIcon/>
                                                                        </InputAdornment>
                                                                    )
                                                                }}
                                                            />
                                                        </FormControl>
                                                    </Box>
                                                    <Box sx={{maxWidth: 305, minWidth: 305}}>
                                                        <FormControl fullWidth size="small">
                                                            <TextField
                                                                id="date"
                                                                label="End Date"
                                                                type="date"
                                                                size="small"
                                                                value={endDateForAdd}
                                                                onChange={(e) => setEndDateForAdd(e.target.value)}
                                                                InputProps={{
                                                                    startAdornment: (
                                                                        <InputAdornment position="start">
                                                                            <InsertInvitationOutlinedIcon/>
                                                                        </InputAdornment>
                                                                    )
                                                                }}
                                                            />
                                                        </FormControl>
                                                    </Box>
                                                </Stack>
                                                <Stack mb={3}>
                                                <Box sx={{maxWidth: 630, minWidth: 630}}>
                                                    <FormControl fullWidth size="small">
                                                        <TextField
                                                            multiline
                                                            type='text'
                                                            size="small"
                                                            label="Information"
                                                            value={infoForAdd}
                                                            onChange={(event) => setInfoForAdd(event.target.value)}
                                                            InputProps={{
                                                                startAdornment: (
                                                                    <InputAdornment position="start">
                                                                        <DnsOutlinedIcon/>
                                                                    </InputAdornment>
                                                                )
                                                            }}
                                                        />
                                                    </FormControl>
                                                </Box>
                                                </Stack>
                                            </Stack>
                                            {eventId > 0 ?
                                                <Button sx={{bottom: 7}} size="large" type="submit"
                                                        variant="contained"
                                                        onClick={() => addNewRecord()}>
                                                    Edit!
                                                </Button>
                                                :
                                                <Button sx={{bottom: 7}} size="large" type="submit"
                                                        variant="contained"
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
                    <Grid container sx={{flexDirection: 'row', paddingLeft: 5, top: 10}}>
                        <>
                            {isLoading === true ?
                                <Stack sx={{color: 'grey.500', paddingLeft: 55, paddingTop: 25}} spacing={2} direction="row"
                                       justifyContent='center' alignSelf='center' left='50%'>
                                    <CircularProgress color="inherit"/>
                                </Stack>
                                :
                                <>
                                    {tasks.length > 0 ? (
                                        <>
                                            {tasks.map((row) => (
                                                <Card sx={{maxWidth: 300, minWidth: 300, marginTop: 5, marginRight: 5}}>
                                                    <CardContent>
                                                        <Typography gutterBottom variant="h6" component="div" sx={{ p: 1.6, border: '1px dashed #b1b9be', borderRadius:1, }}
                                                                    key={row.EventtId}>
                                                            {row.Title}
                                                        </Typography>
                                                        <Stack sx={{flexDirection: 'row', paddingTop: 1}}>
                                                            <Typography variant="body2" color="text.secondary">
                                                                <Label variant="ghost" color="success" sx={{fontSize:13}}>
                                                                    Start Date: </Label>{days[new Date(row.StartDate).getDay()]}  {monthNames[new Date(row.StartDate).getMonth()]} {format(new Date(row.StartDate), 'dd kk:mm')}
                                                            </Typography>
                                                        </Stack>
                                                        <Stack sx={{flexDirection: 'row'}} mt={2}>
                                                            <Typography variant="body2" color="text.secondary">
                                                                <Label variant="ghost" color="error" sx={{fontSize:13}}>
                                                                     End Date: </Label> {days[new Date(row.EndDate).getDay()]} {monthNames[new Date(row.EndDate).getMonth()]} {format(new Date(row.EndDate), 'dd kk:mm')}
                                                            </Typography>
                                                        </Stack>
                                                        <CardActions sx={{paddingTop: 2, paddingLeft:0, paddingBottom:0}}>
                                                            <IconButton disableRipple sx={{ ml: 0, "&.MuiButtonBase-root:hover": {bgcolor: "transparent"}}}>
                                                                <AccountStyle onClick={() => modalForEdit(row.EventtId)} sx={{ p: 1.6, border: '1px dashed #b1b9be', '&:hover': {backgroundColor: '#F4F6F8', boxShadow: 'none'}}}>
                                                                    <Icon icon={roundUpdate} width={20} height={20}/>
                                                                    <Box sx={{ ml: 1 }}>
                                                                        <Typography variant="subtitle2" sx={{ color: 'text.primary' }}>
                                                                            Edit
                                                                        </Typography>
                                                                    </Box>
                                                                </AccountStyle>
                                                            </IconButton>
                                                            <IconButton disableRipple sx={{ ml: 0, "&.MuiButtonBase-root:hover": {bgcolor: "transparent"}}}>
                                                                <AccountStyle onClick={() => getByIdTasks(row.EventtId)} sx={{ p: 1.6, border: '1px dashed #b1b9be', '&:hover': {backgroundColor: '#F4F6F8', boxShadow: 'none'}}}>
                                                                    <Icon icon={layersOutline} width={20} height={20} />
                                                                    <Box sx={{ ml: 1 }}>
                                                                        <Typography variant="subtitle2" sx={{ color: 'text.primary' }}>
                                                                            Details
                                                                        </Typography>
                                                                    </Box>
                                                                </AccountStyle>
                                                            </IconButton>
                                                            <Modal sx={{backgroundColor: "rgba(0, 0, 0, 0.15)"}}
                                                                   hideBackdrop={true}
                                                                   disableEscapeKeyDown={true}
                                                                   open={openModalForDetails}
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
                                                                    <Stack mb={2} flexDirection="row"
                                                                           justifyContent='space-between'>
                                                                        <Typography id="modal-modal-title"
                                                                                    variant="h6" component="h2">
                                                                            Details!
                                                                        </Typography>
                                                                        <IconButton sx={{bottom: 4}}>
                                                                            <CloseIcon onClick={handleClosModal}/>
                                                                        </IconButton>
                                                                    </Stack>
                                                                    <Stack mb={0} justifyContent="space-around">
                                                                        <Box sx={{minWidth: 300}}>
                                                                            <TableContainer component={Paper} keey>
                                                                                <Table aria-label="simple table">
                                                                                    <TableRow sx={{
                                                                                        backgroundColor: '#f7f7f7',
                                                                                        padding: 15,
                                                                                        border: '6px solid #fff'
                                                                                    }}>
                                                                                        <TableCell
                                                                                            variant="head">Title</TableCell>
                                                                                        <TableCell>{titleForAdd}</TableCell>
                                                                                    </TableRow>
                                                                                    <TableRow sx={{
                                                                                        backgroundColor: '#f7f7f7',
                                                                                        padding: 15,
                                                                                        border: '6px solid #fff'
                                                                                    }}>
                                                                                        <TableCell variant="head">Start
                                                                                            Date</TableCell>
                                                                                        <TableCell>{format(new Date(startDateForAdd), 'dd/MM/yyyy')}</TableCell>
                                                                                    </TableRow>
                                                                                    <TableRow sx={{
                                                                                        backgroundColor: '#f7f7f7',
                                                                                        padding: 15,
                                                                                        border: '6px solid #fff'
                                                                                    }}>
                                                                                        <TableCell variant="head">End
                                                                                            Date</TableCell>
                                                                                        <TableCell>{format(new Date(endDateForAdd), 'dd/MM/yyyy')}</TableCell>
                                                                                    </TableRow>
                                                                                    <TableRow sx={{
                                                                                        backgroundColor: '#f7f7f7',
                                                                                        padding: 15,
                                                                                        border: '6px solid #fff'
                                                                                    }}>
                                                                                        <TableCell variant="head">Event
                                                                                            Type</TableCell>
                                                                                        <TableCell>{eventTypeName}</TableCell>
                                                                                    </TableRow>
                                                                                    <TableRow sx={{
                                                                                        backgroundColor: '#f7f7f7',
                                                                                        padding: 15,
                                                                                        border: '6px solid #fff'
                                                                                    }}>
                                                                                        <TableCell
                                                                                            variant="head">Client</TableCell>
                                                                                        <TableCell>{clientName}</TableCell>
                                                                                    </TableRow>
                                                                                    <TableRow sx={{
                                                                                        backgroundColor: '#f7f7f7',
                                                                                        padding: 15,
                                                                                        border: '6px solid #fff'
                                                                                    }}>
                                                                                        <TableCell variant="head">Case
                                                                                            No</TableCell>
                                                                                        <TableCell>{caseNo}</TableCell>
                                                                                    </TableRow>
                                                                                    <TableRow sx={{
                                                                                        backgroundColor: '#f7f7f7',
                                                                                        padding: 15,
                                                                                        border: '6px solid #fff'
                                                                                    }}>
                                                                                        <TableCell
                                                                                            variant="head">User</TableCell>
                                                                                        <TableCell>{userName}</TableCell>
                                                                                    </TableRow>
                                                                                    <TableRow sx={{
                                                                                        backgroundColor: '#f7f7f7',
                                                                                        padding: 15,
                                                                                        border: '6px solid #fff'
                                                                                    }}>
                                                                                        <TableCell
                                                                                            variant="head">Info</TableCell>
                                                                                        <TableCell>{infoForAdd}</TableCell>
                                                                                    </TableRow>
                                                                                </Table>
                                                                            </TableContainer>
                                                                        </Box>
                                                                    </Stack>
                                                                </Box>
                                                            </Modal>
                                                        </CardActions>
                                                    </CardContent>
                                                </Card>
                                            ))}
                                        </>
                                    ) : (
                                        <card sx={{width: '40%'}}>
                                            <img src="/static/illustrations/no.png" alt="login"/>
                                            <Typography variant="h3" gutterBottom textAlign='center' color='#a9a9a9'>No
                                                Data
                                                Found</Typography>
                                        </card>
                                    )}
                                </>
                            }
                        </>
                    </Grid>

                </Container>
                    }
        </Page>
    );
}


import {Icon} from '@iconify/react';
import 'react-datepicker/dist/react-datepicker.css';
import plusFill from '@iconify/icons-eva/plus-fill';
import {format} from 'date-fns';
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
    IconButton, CardContent, Collapse, tableCellClasses
} from '@mui/material';
// components
import Page from '../components/Page';
//
import trash2Outline from '@iconify/icons-eva/trash-2-outline';
import Modal from "@mui/material/Modal";
import CloseIcon from "@material-ui/icons/Close";
import FormControl from "@mui/material/FormControl";
import CreditCardOutlinedIcon from '@mui/icons-material/CreditCardOutlined';
import TextSnippetOutlinedIcon from '@mui/icons-material/TextSnippetOutlined';
import MonetizationOnOutlinedIcon from '@mui/icons-material/MonetizationOnOutlined';
import EventOutlinedIcon from '@mui/icons-material/EventOutlined';
import AttachMoneyIcon from '@mui/icons-material/AttachMoney';
import MenuItem from "@mui/material/MenuItem";
import React, {useEffect, useState} from "react";
import PopupMessageService from "../services/popupMessage.service";
import AuthService from "../services/auth.service";
import {Global} from "../Global";
import ReceiptLongOutlinedIcon from '@mui/icons-material/ReceiptLongOutlined';
import TransactionActivityTypeService from "../services/transactionActivityType.service";
import AccountActivityService from "../services/AccountActivity.service";
import TransactionActivitiesService from "../services/TransactionActivities.service";
import Scrollbar from "../components/Scrollbar";
import CircularProgress from "@mui/material/CircularProgress";
import Label from "../components/Label";
import roundUpdate from "@iconify/icons-ic/round-update";
import KeyboardArrowUpIcon from "@mui/icons-material/KeyboardArrowUp";
import KeyboardArrowDownIcon from "@mui/icons-material/KeyboardArrowDown";
import Alert from "@mui/material/Alert";
import {useNavigate} from "react-router-dom";
// ----------------------------------------------------------------------

export default function AccountActivities() {

    const today = new Date();
    const date = today.setDate(today.getDate());
    const defaultValue = new Date(date).toISOString().split('T')[0]
    const popupMessageService = new PopupMessageService();
    const authService = new AuthService();
    const catchMessagee = Global.catchMessage;
    const tatService = new TransactionActivityTypeService();
    const tastService = new AccountActivityService();
    const transactionActivitiesService = new TransactionActivitiesService();
    const [open, setOpen] = React.useState(false);
    const [openModal, setOpenModal] = useState(false);
    const [isLoading, setIsLoading] = useState(true);
    const [tats, setTats] = useState([]);
    const [isItExpenseForUpdate, setIsItExpenseForUpdate] = useState(-1);
    const [time, setTime] = useState(true);
    const navigate = useNavigate();
    //Transaction activity sub types
    const [tasts, setTasts] = useState([]);
    //selected transaction activity type id
    const [selectedTatId, setselectedTatId] = useState(0)
    const [selectedTastId, setselectedTastId] = useState(0)
    const [transactionActivityIdForUpdate, setTransactionActivityIdForUpdate] = useState(0)
    const [infoForUpdate, setInfoForUpdate] = useState("")
    const [amountForUpdate, setAmountForUpdate] = useState(0)
    const [dateForUpdate, setDateForUpdate] = useState(defaultValue)
    const [totalBalance, setTotalBalance] = useState(0)
    const [totalExpense, setTotalExpense] = useState(0)
    const [totalIncome, setTotalIncome] = useState(0)
    const [transactionActivityGetAll, setTransactionActivityGetAll] = useState([]);
    const [transactionActivityTypeForFilter, setTransactionActivityTypeForFilter] = useState(-1);
    const [isErrorMessage, setIsErrorMessage] = useState(false);
    const [errorMessage, setErrorMessage] = useState('');

    function filtering(transactionActivityGetAll) {
        let filterdeTransactionActivities = transactionActivityGetAll
        if (transactionActivityTypeForFilter > 0)
            filterdeTransactionActivities = filterdeTransactionActivities.filter(c => c.TransactionActivitySubTypeGetDto.TransactionActivityType.TransactionActivityTypeId === transactionActivityTypeForFilter)
        return filterdeTransactionActivities
    }

    function handleTatChange(TatId) {
        getAllTasts(TatId)
        setselectedTatId(TatId)
    }

    const handleOpen = () => {
        setTransactionActivityIdForUpdate(0)
        setInfoForUpdate("")
        setAmountForUpdate(0)
        setDateForUpdate(defaultValue)
        setIsItExpenseForUpdate(-1)
        setIsErrorMessage(false)
        setErrorMessage("")
        setOpenModal(true)
    };
    const handleClose = () => {
        setOpenModal(false)
    };

    function getAllTats() {
        tatService.getAll().then(result => {
                setTats(result.data.Data)
                setselectedTatId(result.data.Data[0].TransactionActivityTypeId)
                getAllTasts(result.data.Data[0].TransactionActivityTypeId)
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    }

    function getAllTasts(selectedId) {
        tastService.getAllByTransactionActivityId(selectedId).then(result => {
                let id = result.data.Data[0].TransactionAcitivitySubTypeId
                setselectedTastId(id)
                setTasts(result.data.Data)
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    }

    const getAllTransactionActivities = () => {
        transactionActivitiesService.getAll().then(
            (result) => {
                if (result.data.Success) {
                    setTransactionActivityGetAll(result.data.Data)
                    setIsLoading(false)
                    getAllTotalBalance()
                    getAllTotalExpense()
                    getAllTotalIncome()
                }
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    };
    const getAllTotalBalance = () => {
        transactionActivitiesService.totalBalance().then(
            (result) => {
                if (result.data.Success) {
                    setTotalBalance(result.data.Data)
                }
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    };

    const getAllTotalExpense = () => {
        transactionActivitiesService.totalExpense().then(
            (result) => {
                if (result.data.Success) {
                    setTotalExpense(result.data.Data)
                }
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    };
    const getAllTotalIncome = () => {
        transactionActivitiesService.totalIncome().then(
            (result) => {
                if (result.data.Success) {
                    setTotalIncome(result.data.Data)
                }
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    };

    function deleteTransactionActivity(id) {
        transactionActivitiesService.delete(id).then(result => {
                if (result.data.Success) {
                    getAllTransactionActivities()
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


    function modalForEdit(id) {
        transactionActivitiesService.getById(id).then(result => {
            if (result.data.Success) {
                let edit = result.data.Data
                setTransactionActivityIdForUpdate(edit.TransactionActivityId)
                setselectedTastId(edit.TransactionActivitySubTypeGetDto.TransactionAcitivitySubTypeId)
                setInfoForUpdate(edit.Info)
                setselectedTatId(edit.TransactionActivitySubTypeGetDto.TransactionActivityType.TransactionActivityTypeId)
                setAmountForUpdate(edit.Amount)
                setDateForUpdate(edit.StartDate)
                setIsItExpenseForUpdate(isItExpenseForUpdate)

            }
        })
        setOpenModal(true)
    }

    function addNewRecord() {
        let obj = {
            transactionActivityId: transactionActivityIdForUpdate,
            transactionActivitySubTypeId: selectedTastId,
            info: infoForUpdate,
            amount: amountForUpdate,
            date: dateForUpdate,
            isItExpense: isItExpenseForUpdate
        }
        let re
        if (transactionActivityIdForUpdate > 0) {
            obj.TransactionActivityId = transactionActivityIdForUpdate
            re = transactionActivitiesService.update(obj)
        } else {
            re = transactionActivitiesService.add(obj)
        }
        re.then((result) => {
                if (result.data.Success) {
                    getAllTransactionActivities()
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
    if(authService.DoesHaveMandatoryClaim('TransactionActivityGetAll')||
        authService.DoesHaveMandatoryClaim('LicenceOwner')) {
        getAllTats()
        getAllTransactionActivities()
        getAllTotalBalance()
        getAllTotalExpense()
        getAllTotalIncome()
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
                            Transaction Activities
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
                                            borderRadius: 2
                                        }}
                                    >
                                        <Stack mb={5} flexDirection="row" justifyContent='space-between'>
                                            {transactionActivityIdForUpdate > 0 ?
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
                                                    {tats.length > 0 ? (
                                                        <Box sx={{minWidth: 305}}>
                                                            <FormControl fullWidth size="small">
                                                                <TextField
                                                                    select
                                                                    size='small'
                                                                    label="Expense"
                                                                    value={selectedTatId}
                                                                    onChange={(e) => handleTatChange(e.target.value)}
                                                                    key={Math.random().toString(36).substr(2, 9)}
                                                                    InputProps={{
                                                                        startAdornment: (
                                                                            <InputAdornment position="start">
                                                                                <ReceiptLongOutlinedIcon/>
                                                                            </InputAdornment>
                                                                        )
                                                                    }}
                                                                >
                                                                    {tats.map((item) => (
                                                                        <MenuItem
                                                                            key={Math.random().toString(36).substr(2, 9)}
                                                                            value={item.TransactionActivityTypeId}
                                                                        >
                                                                            {item.TransactionActivityTypeName}
                                                                        </MenuItem>
                                                                    ))}
                                                                </TextField>
                                                            </FormControl>
                                                        </Box>
                                                    ) : null}
                                                {tasts.length > 0 ? (
                                                        <Box sx={{minWidth: 305}}>
                                                            <FormControl fullWidth size="small">
                                                                <TextField
                                                                    select
                                                                    size='small'
                                                                    label="Other"
                                                                    value={selectedTastId}
                                                                    onChange={(e) => setselectedTastId(e.target.value)}
                                                                    key={Math.random().toString(36).substr(2, 9)}
                                                                    InputProps={{
                                                                        startAdornment: (
                                                                            <InputAdornment position="start">
                                                                                <CreditCardOutlinedIcon/>
                                                                            </InputAdornment>
                                                                        )
                                                                    }}
                                                                >
                                                                    {tasts.map((item) => (
                                                                        <MenuItem
                                                                            key={Math.random().toString(36).substr(2, 9)}
                                                                            value={item.TransactionAcitivitySubTypeId}
                                                                        >
                                                                            {item.TransactionAcitivitySubTypeName}
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
                                                                select
                                                                size='small'
                                                                value={isItExpenseForUpdate}
                                                                key={Math.random().toString(36).substr(2, 9)}
                                                                label="Expense or Incoming"
                                                                onChange={(e) => setIsItExpenseForUpdate(e.target.value)}
                                                                InputProps={{
                                                                    startAdornment: (
                                                                        <InputAdornment position="start">
                                                                            <AttachMoneyIcon/>
                                                                        </InputAdornment>
                                                                    )
                                                                }}
                                                            >
                                                                <MenuItem key={Math.random().toString(36).substr(2, 9)}
                                                                          value={-1}>Expense</MenuItem>
                                                                <MenuItem key={Math.random().toString(36).substr(2, 9)}
                                                                          value={0}>
                                                                    Incoming
                                                                </MenuItem>
                                                            </TextField>
                                                        </FormControl>
                                                    </Box>
                                                    <Box sx={{minWidth: 305}}>
                                                        <FormControl fullWidth size="small">
                                                            <TextField
                                                                type="number"
                                                                label="Amount"
                                                                size="small"
                                                                value={amountForUpdate}
                                                                onChange={(e) => setAmountForUpdate(e.target.value)}
                                                                InputProps={{
                                                                    startAdornment: (
                                                                        <InputAdornment position="start">
                                                                            <MonetizationOnOutlinedIcon/>
                                                                        </InputAdornment>
                                                                    )
                                                                }}
                                                            />
                                                        </FormControl>
                                                    </Box>
                                                </Stack>
                                                <Stack mb={3}>
                                                    <Box sx={{minWidth: 630}}>
                                                        <FormControl fullWidth size="small">
                                                            <TextField
                                                                id="date"
                                                                label="Date"
                                                                type="date"
                                                                size="small"
                                                                value={dateForUpdate}
                                                                onChange={(e) => setDateForUpdate(e.target.value)}
                                                                InputProps={{
                                                                    startAdornment: (
                                                                        <InputAdornment position="start">
                                                                            <EventOutlinedIcon/>
                                                                        </InputAdornment>
                                                                    )
                                                                }}
                                                            />
                                                        </FormControl>
                                                    </Box>
                                                </Stack>
                                                <Stack mb={3}>
                                                    <Box sx={{minWidth: 630}}>
                                                        <FormControl fullWidth size="small">
                                                            <TextField
                                                                type="text"
                                                                multiline
                                                                label="Explanation"
                                                                size="small"
                                                                value={infoForUpdate}
                                                                onChange={(e) => setInfoForUpdate(e.target.value)}
                                                                InputProps={{
                                                                    startAdornment: (
                                                                        <InputAdornment position="start">
                                                                            <TextSnippetOutlinedIcon/>
                                                                        </InputAdornment>
                                                                    )
                                                                }}
                                                            />
                                                        </FormControl>
                                                    </Box>
                                                </Stack>
                                            </Stack>
                                            {transactionActivityIdForUpdate > 0 ?
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
                                Transaction Activity Type
                            </Typography>
                            {tats.length > 0 ? (
                                <Box sx={{minWidth: 350}}>
                                    <FormControl fullWidth size="small">
                                        <TextField
                                            select
                                            size='small'
                                            label="Transaction Activity Type"
                                            value={transactionActivityTypeForFilter}
                                            onChange={(e) => setTransactionActivityTypeForFilter(e.target.value)}

                                            key={Math.random().toString(36).substr(2, 9)}
                                            InputProps={{
                                                startAdornment: (
                                                    <InputAdornment position="start">
                                                        <ReceiptLongOutlinedIcon/>
                                                    </InputAdornment>
                                                )
                                            }}
                                        >
                                            <MenuItem key={Math.random().toString(36).substr(2, 9)} value={-1}>
                                                All
                                            </MenuItem>
                                            {tats.map((item) => (
                                                <MenuItem
                                                    key={Math.random().toString(36).substr(2, 9)}
                                                    value={item.TransactionActivityTypeId}
                                                >
                                                    {item.TransactionActivityTypeName}
                                                </MenuItem>
                                            ))}
                                        </TextField>
                                    </FormControl>
                                </Box>
                            ) : null}
                        </Stack>
                        <Card sx={{maxWidth: 580, maxHeight: 170, marginTop: 2, marginRight: 0, marginBottom: 3}}>
                            <CardContent>
                                <Stack flexDirection='row'>
                                    <Stack flexDirection='row'>
                                        <Typography fontSize={14}>Total Balance</Typography>
                                        <Stack flexDirection='row'>
                                            <Typography variant="h5" gutterBottom component="div" color='#959ea3' sx={{
                                                borderRight: '1px dashed #b1b9be',
                                                padding: '0.4em',
                                                p: 4,
                                                maxHeight: 50
                                            }}>
                                                <Label variant="ghost" color="primary" sx={{fontSize: 15}}>
                                                    {totalBalance} ₺</Label>
                                            </Typography>
                                        </Stack>
                                    </Stack>
                                    <Stack flexDirection='row' paddingLeft={3}>
                                        <Typography fontSize={14}>Total Expense</Typography>
                                        <Typography variant="h5" gutterBottom component="div" color='#c9505c' sx={{
                                            borderRight: '1px dashed #b1b9be',
                                            padding: '0.4em',
                                            p: 4,
                                            maxHeight: 50
                                        }}>
                                            <Label variant="ghost" color="error" sx={{fontSize: 15}}>
                                                -{totalExpense} ₺</Label>
                                        </Typography>
                                    </Stack>
                                    <Stack flexDirection='row' paddingLeft={3}>
                                        <Stack flexDirection='row'>
                                            <Typography fontSize={14}>Total Income</Typography>
                                        </Stack>
                                    </Stack>
                                    <Typography variant="h5" gutterBottom component="div" color='#437a54' sx={{
                                        borderRight: '1px dashed #fff',
                                        padding: '0.4em',
                                        p: 4,
                                        maxHeight: 50
                                    }}>
                                        <Label variant="ghost" color="success" sx={{fontSize: 15}}>
                                            {totalIncome} ₺</Label>
                                    </Typography>
                                </Stack>
                            </CardContent>
                        </Card>
                    </Stack>
                    <Card sx={{marginTop: -3}}>
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
                                            <Table sx={{minWidth: 650}} aria-label="simple table">
                                                <TableHead>
                                                    <TableRow>
                                                        <TableCell sx={{paddingLeft: 7}}>Transaction Activity
                                                            Type</TableCell>
                                                        <TableCell align="left">Transaction Activity subtype</TableCell>
                                                        <TableCell align="left">Date</TableCell>
                                                        <TableCell align="left">Name Surname</TableCell>
                                                        <TableCell align="left">Amount</TableCell>
                                                        <TableCell align="left">Edit</TableCell>
                                                        <TableCell align="left">Delete</TableCell>
                                                        <TableCell align="left">Details</TableCell>
                                                        <TableCell align="right"/>
                                                    </TableRow>
                                                </TableHead>
                                                <TableBody>
                                                    <>
                                                        {filtering(transactionActivityGetAll).map((row) => (
                                                            <>
                                                                <TableRow
                                                                    key={row.TransactionActivityId}
                                                                    sx={{'&:last-child td, &:last-child th': {border: 0}}}
                                                                >
                                                                    <TableCell component="th" scope="row"
                                                                               sx={{paddingLeft: 7}}>
                                                                        {row.TransactionActivitySubTypeGetDto.TransactionActivityType.TransactionActivityTypeName}
                                                                    </TableCell>
                                                                    <TableCell component="th" scope="row">
                                                                        {row.TransactionActivitySubTypeGetDto.TransactionAcitivitySubTypeName}
                                                                    </TableCell>
                                                                    <TableCell component="th" scope="row">
                                                                        {format(new Date(row.Date), 'dd/MM/yyyy')}
                                                                    </TableCell>
                                                                    <TableCell component="th" scope="row">
                                                                        {row.UserWhoAdd.FirstName} {row.UserWhoAdd.LastName}
                                                                    </TableCell>
                                                                    {row.IsItExpense ? (
                                                                        <TableCell component="th" scope="row">
                                                                            <Label variant="ghost" color="error"
                                                                                   sx={{fontSize: 15}}>
                                                                                - {row.Amount} ₺
                                                                            </Label>
                                                                        </TableCell>
                                                                    ) : (
                                                                        <TableCell component="th" scope="row">
                                                                            <Label variant="ghost" color="success"
                                                                                   sx={{fontSize: 15}}>
                                                                                {row.Amount} ₺
                                                                            </Label>
                                                                        </TableCell>
                                                                    )}
                                                                    <TableCell>
                                                                        <Button
                                                                            onClick={() => modalForEdit(row.TransactionActivityId)}
                                                                            variant="contained"
                                                                            sx={{backgroundColor: '#b1b9be'}}
                                                                            startIcon={<Icon icon={roundUpdate}/>}
                                                                        >
                                                                            Edit
                                                                        </Button>
                                                                    </TableCell>
                                                                    {authService.DoesHaveMandatoryClaim('TransactionActivityDelete') || authService.DoesHaveMandatoryClaim('LicenceOwner') ? (
                                                                        <>
                                                                            <TableCell align="right">
                                                                                <Button
                                                                                    onClick={() => deleteTransactionActivity(row.TransactionActivityId)}
                                                                                    variant="contained"
                                                                                    sx={{backgroundColor: '#c9505c'}}
                                                                                    startIcon={<Icon
                                                                                        icon={trash2Outline}/>}>Delete</Button>
                                                                            </TableCell>
                                                                        </>
                                                                    ) : null}
                                                                    <TableCell>
                                                                        <IconButton
                                                                            sx={{marginLeft: 1}}
                                                                            aria-label="expand row"
                                                                            size="small"
                                                                            onClick={() =>
                                                                                setOpen((prev) => ({
                                                                                    ...prev,
                                                                                    [row.TransactionActivityId]: !prev[row.TransactionActivityId]
                                                                                }))
                                                                            }
                                                                        >
                                                                            {open[row.TransactionActivityId] ?
                                                                                <KeyboardArrowUpIcon/> :
                                                                                <KeyboardArrowDownIcon/>}
                                                                        </IconButton>
                                                                    </TableCell>
                                                                    <TableCell align="right"/>
                                                                </TableRow>
                                                                <TableRow>
                                                                    <TableCell style={{paddingBottom: 0, paddingTop: 0}}
                                                                               colSpan={9}>
                                                                        <Collapse in={open[row.TransactionActivityId]}
                                                                                  timeout="auto" unmountOnExit>
                                                                            {open[row.TransactionActivityId] && (
                                                                                <Box sx={{margin: 1, padding: 1.5}}>
                                                                                    <Table size="small"
                                                                                           aria-label="purchases" sx={{
                                                                                        [`& .${tableCellClasses.root}`]: {
                                                                                            border: '2px solid #fff',
                                                                                            backgroundColor: '#fafafa'
                                                                                        }
                                                                                    }}>
                                                                                        <TableHead>
                                                                                            <TableRow>
                                                                                                <TableCell
                                                                                                    component="th"
                                                                                                    scope="row"
                                                                                                    align="left">Title</TableCell>
                                                                                                <TableCell align="left">Full
                                                                                                    Name</TableCell>
                                                                                                <TableCell
                                                                                                    align="left">CellPhone</TableCell>
                                                                                                <TableCell
                                                                                                    align="left">Info</TableCell>
                                                                                            </TableRow>
                                                                                        </TableHead>
                                                                                        <TableBody>
                                                                                            <TableRow sx={{
                                                                                                [`& .${tableCellClasses.root}`]: {
                                                                                                    borderBottom: "none"
                                                                                                }
                                                                                            }}>
                                                                                                <TableCell
                                                                                                    component="th"
                                                                                                    scope="row">
                                                                                                    {row.UserWhoAdd.Title}
                                                                                                </TableCell>
                                                                                                <TableCell
                                                                                                    component="th"
                                                                                                    scope="row">
                                                                                                    {row.UserWhoAdd.FirstName} {row.UserWhoAdd.LastName}
                                                                                                </TableCell>
                                                                                                <TableCell
                                                                                                    component="th"
                                                                                                    scope="row">
                                                                                                    {row.UserWhoAdd.CellPhone}
                                                                                                </TableCell>
                                                                                                <TableCell
                                                                                                    component="th"
                                                                                                    scope="row">
                                                                                                    {row.Info}
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
                                                Data
                                                Found</Typography>
                                        </TableCell>
                                    )}
                                </>
                            }
                        </Scrollbar>
                    </Card>
                </Container>
            }
        </Page>
    );
}

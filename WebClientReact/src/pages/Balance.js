import React, {useEffect, useState} from "react";
import {styled} from '@mui/material/styles';
import {
    Box,
    Button,
    Card,
    Container,
    IconButton,
    InputAdornment,
    Link,
    Stack,
    TextField,
    Typography
} from '@mui/material';
// components
import Page from '../components/Page';
import Cards from 'react-credit-cards';
import 'react-credit-cards/es/styles-compiled.css'
import {Global} from "../Global";
import PaymentsService from "../services/payments.service";
import PopupMessageService from "../services/popupMessage.service";
import AuthLayout from "../layouts/AuthLayout";
import {Link as RouterLink, useNavigate} from "react-router-dom";
import {MHidden} from "../components/@material-extend";
import CircularProgress from "@mui/material/CircularProgress";
import CreditCardOutlinedIcon from '@mui/icons-material/CreditCardOutlined';
import BadgeOutlinedIcon from '@mui/icons-material/BadgeOutlined';
import EventBusyOutlinedIcon from '@mui/icons-material/EventBusyOutlined';
import NotificationsNoneIcon from '@mui/icons-material/NotificationsNone';
import GppGoodOutlinedIcon from '@mui/icons-material/GppGoodOutlined';
import MonetizationOnOutlinedIcon from '@mui/icons-material/MonetizationOnOutlined';
import CreditCardRemindersService from "../services/creditCardReminders.service";
import MenuItem from "@mui/material/MenuItem";
import {Icon} from "@iconify/react";
import plusFill from "@iconify/icons-eva/plus-fill";
import CloseIcon from "@material-ui/icons/Close";
import Modal from "@mui/material/Modal";
import arrowBackOutline from "@iconify/icons-eva/arrow-back-outline";
// ----------------------------------------------------------------------

export default function Balance() {
    const [fullNameCard, setFullNameCard] = useState("");
    const [creditCardNoCard, setCreditCardNoCard] = useState("");
    const [latestMonthCard, setLatestMonthCard] = useState("");
    const [latestYearCard, setLatestYearCard] = useState("");
    const [securityCodeCard, setSecurityCodeCard] = useState("");
    const [newReminderId, setNewReminderId] = useState(0);
    const [howMuchBalanceLoadedCard, setHowMuchBalanceLoadedCard] = useState("");
    const [focus, setFocus] = useState("")
    const [isLoading, setIsLoading] = useState(false);
    const [allReminders, setAllReminders] = useState([]);
    const [remindersId, setReminderId] = useState(0);
    const [openModal, setOpenModal] = useState(false);

    const navigate = useNavigate();
    const catchMessagee = Global.catchMessage;
    const paymentsService = new PaymentsService();
    const creditCardRemindersService = new CreditCardRemindersService();
    const popupMessageService = new PopupMessageService();

    const handleOpen = () => {
        setNewReminderId(0)
        setFullNameCard("")
        setCreditCardNoCard("")
        setLatestMonthCard("")
        setLatestYearCard("")
        setSecurityCodeCard("")
        setOpenModal(true)
    };
    const handleClose = () => {
        setOpenModal(false)
    };

    function handleReminderChange(TatId) {
        getByIdCreditCard(TatId)
        setReminderId(TatId)
    }

    function getByIdCreditCard(id) {
        creditCardRemindersService.getById(id).then(result => {
            if (result.data.Success) {
                let card = result.data.Data
                setNewReminderId(card.Id)
                setFullNameCard(card.FullName)
                setCreditCardNoCard(card.CreditCardNo)
                setLatestMonthCard(card.LatestMonth)
                setLatestYearCard(card.LatestYear)
                setSecurityCodeCard(card.SecurityCode)
            }
        })
    }

    const getAllReminders = () => {
        creditCardRemindersService
            .getAll()
            .then(
                (response) => {
                    setAllReminders(response.data.Data);
                    const CreditCardReminderFromApi = response.data.Data;
                    const list = [];
                    CreditCardReminderFromApi.forEach((item) => {
                        list.push({
                            value: item.Id,
                            label: item.Content,
                            key: item.Content
                        });
                    });
                    setAllReminders(list);
                },
                (error) => {
                    popupMessageService.AlertErrorMessage(error.response.data.Message);
                }
            )
            .catch(() => {
                popupMessageService.AlertErrorMessage(catchMessagee)
            });
    };

    function addBalance() {
        let obj = {
            fullName: fullNameCard,
            creditCardNo: creditCardNoCard,
            latestMonth: latestMonthCard,
            latestYear: latestYearCard,
            securityCode: securityCodeCard,
            howMuchBalanceLoaded: howMuchBalanceLoadedCard
        }
        paymentsService.makePayment(obj)
            .then((result) => {
                    if (result.data.Success) {
                        setIsLoading(false)
                        popupMessageService.AlertSuccessMessage(result.data.Message)
                            .then(r => {
                                creditCardRemindersService.checkCreditCardIsExist(creditCardNoCard).then(
                                    (result) => {
                                        if (result.data.Data) {
                                            popupMessageService.AlertAssuranceMessage('Do you want your credit card to be saved?')
                                                .then((result2) => {
                                                    if (result2.isConfirmed) {
                                                        addNewRecord()
                                                    } else {
                                                        navigate('/dashboard/licenceSettings');
                                                    }
                                                })
                                            setIsLoading(false)
                                        }
                                    },
                                    (error) => {
                                        popupMessageService.AlertErrorMessage(error.response.data.Message);
                                    }
                                ).catch(() => {
                                    popupMessageService.AlertErrorMessage(catchMessagee)
                                })
                            })
                    }
                },
                (error) => {
                    popupMessageService.AlertErrorMessage(error.response.data.Message);
                }
            ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    }

    function addNewRecord() {
        let obj = {
            id: newReminderId,
            fullName: fullNameCard,
            creditCardNo: creditCardNoCard,
            latestMonth: latestMonthCard,
            latestYear: latestYearCard,
            securityCode: securityCodeCard,
        }
        let re
        if (newReminderId > 0) {
            obj.Id = newReminderId
            re = creditCardRemindersService.update(obj)
        } else {
            re = creditCardRemindersService.add(obj)
        }
        re.then((result) => {
                if (result.data.Success) {
                    setOpenModal(false)
                    popupMessageService.AlertSuccessMessage(result.data.Message)
                    getAllReminders()
                }
            },
            (error) => {
                setOpenModal(false)
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    }

    useEffect(() => {
        getAllReminders();
    }, [])

    return (
        <Page title="Profile | MediLaw">
            <Container>
                <Stack direction="row" alignItems="center" justifyContent="flex-star" mb={4}>
                    <Stack direction="row" alignItems="center" justifyContent="flex-start" mb={4}>
                        <IconButton onClick={() => navigate(-1)} sx={{ mr: 3, color: 'text.primary', bottom:3 }} size="large">
                            <Icon icon={arrowBackOutline} />
                        </IconButton>
                        <Typography variant="h4" gutterBottom>
                            Balance
                        </Typography>
                        <Stack direction="row" alignItems="center" justifyContent="space-between" marginLeft={87}>
                            <Button onClick={handleOpen} variant="contained" startIcon={<Icon icon={plusFill}/>}>
                                Edit Record
                            </Button>
                        </Stack>
                    </Stack>

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
                            width: 470,
                            backgroundColor: 'background.paper',
                            border: '2px solid #fff',
                            boxShadow: 24,
                            p: 4,
                            borderRadius: 2
                        }}>
                            <Stack mb={3} flexDirection="row" justifyContent='space-between'>
                                <Typography id="modal-modal-title" variant="h6" component="h2">
                                    Edit record!
                                </Typography>
                                <IconButton sx={{bottom: 4}}>
                                    <CloseIcon onClick={handleClose}/>
                                </IconButton>
                            </Stack>
                            <Stack spacing={3} mb={3}>
                                {allReminders.length > 0 ? (
                                    <TextField
                                        select
                                        label="Credit Card Reminder"
                                        size='small'
                                        fullWidth
                                        value={remindersId}
                                        onChange={(e) => handleReminderChange(e.target.value)}
                                        InputProps={{
                                            startAdornment: (
                                                <InputAdornment position="start">
                                                    <NotificationsNoneIcon/>
                                                </InputAdornment>
                                            )
                                        }}
                                    >
                                        {allReminders.map((item) => (
                                            <MenuItem
                                                key={Math.random().toString(36).substr(2, 9)}
                                                value={item.value}
                                            >
                                                {item.label}
                                            </MenuItem>
                                        ))}
                                    </TextField>
                                ) : null}
                                <TextField
                                    label="Credit Card Number"
                                    name="number"
                                    variant="outlined"
                                    required
                                    size='small'
                                    fullWidth
                                    InputLabelProps={{shrink: true}}
                                    value={creditCardNoCard}
                                    onChange={(e) => setCreditCardNoCard(e.target.value)}
                                    onFocus={(e) => setFocus(e.target.name)}
                                    InputProps={{
                                        startAdornment: (
                                            <InputAdornment position="start">
                                                <CreditCardOutlinedIcon/>
                                            </InputAdornment>
                                        )
                                    }}
                                />
                                <TextField
                                    label="Full Name"
                                    name="name"
                                    fullWidth
                                    variant="outlined"
                                    required
                                    size='small'
                                    InputLabelProps={{shrink: true}}
                                    value={fullNameCard}
                                    onChange={(e) => setFullNameCard(e.target.value)}
                                    onFocus={(e) => setFocus(e.target.name)}
                                    InputProps={{
                                        startAdornment: (
                                            <InputAdornment position="start">
                                                <BadgeOutlinedIcon/>
                                            </InputAdornment>
                                        )
                                    }}
                                />
                                <Stack mb={3} direction={{xs: 'column', sm: 'row'}} spacing={2}>
                                    <TextField
                                        label="Expiration Month"
                                        name="expiry"
                                        id="cardMonth"
                                        data-ref="cardDate"
                                        variant="outlined"
                                        required
                                        size='small'
                                        fullWidth
                                        InputLabelProps={{shrink: true}}
                                        value={latestMonthCard}
                                        onChange={(e) => setLatestMonthCard(e.target.value)}
                                        onFocus={(e) => setFocus(e.target.name)}
                                        InputProps={{
                                            startAdornment: (
                                                <InputAdornment position="start">
                                                    <EventBusyOutlinedIcon/>
                                                </InputAdornment>
                                            )
                                        }}
                                    />
                                    <TextField
                                        label="Expiration Year"
                                        name="expiryyear"
                                        id="cardYear"
                                        data-ref="cardDate"
                                        variant="outlined"
                                        required
                                        size='small'
                                        fullWidth
                                        InputLabelProps={{shrink: true}}
                                        value={latestYearCard}
                                        onChange={(e) => setLatestYearCard(e.target.value)}
                                        onFocus={(e) => setFocus(e.target.name)}
                                        InputProps={{
                                            startAdornment: (
                                                <InputAdornment position="start">
                                                    <EventBusyOutlinedIcon/>
                                                </InputAdornment>
                                            )
                                        }}
                                    />
                                </Stack>
                                <TextField
                                    label="CVC"
                                    name="cvc"
                                    variant="outlined"
                                    required
                                    size='small'
                                    fullWidth
                                    InputLabelProps={{shrink: true}}
                                    value={securityCodeCard}
                                    onChange={(e) => setSecurityCodeCard(e.target.value)}
                                    onFocus={(e) => setFocus(e.target.name)}
                                    InputProps={{
                                        startAdornment: (
                                            <InputAdornment position="start">
                                                <GppGoodOutlinedIcon/>
                                            </InputAdornment>
                                        )
                                    }}
                                />
                                <Button size="large" type="submit" variant="contained"
                                        onClick={() => addNewRecord()}>
                                    Edit!
                                </Button>
                            </Stack>
                        </Box>
                    </Modal>
                </Stack>
                <Stack flexDirection='row' alignItems='space-around' sx={{marginBottom: '0%'}}>
                    <Card justifyContent="center" sx={{padding: 6, maxWidth: 400, minWidth: 400, maxHeight: 285,  marginLeft: 6}}>
                            <Cards
                                number={creditCardNoCard}
                                name={fullNameCard}
                                expiry={latestMonthCard}
                                expiryyear={latestYearCard}
                                cvc={securityCodeCard}
                                focused={focus}
                            />
                    </Card>
                    <Card justifyContent="space-around" sx={{padding: 6, maxWidth: 550, marginLeft: 2}}>
                        <Stack spacing={3}>
                            {allReminders.length > 0 ? (
                                <TextField
                                    select
                                    label="Credit Card Reminder (Optional)"
                                    size='medium'
                                    fullWidth
                                    value={remindersId}
                                    onChange={(e) => handleReminderChange(e.target.value)}
                                    InputProps={{
                                        startAdornment: (
                                            <InputAdornment position="start">
                                                <NotificationsNoneIcon/>
                                            </InputAdornment>
                                        )
                                    }}
                                >
                                    <MenuItem
                                        key={Math.random().toString(36).substr(2, 9)}
                                        value={-1} onClick={() => {
                                        setFullNameCard("")
                                        setCreditCardNoCard("")
                                        setLatestMonthCard("")
                                        setLatestYearCard("")
                                        setSecurityCodeCard("")
                                    }}>None</MenuItem>
                                    {allReminders.map((item) => (
                                        <MenuItem
                                            key={Math.random().toString(36).substr(2, 9)}
                                            value={item.value}
                                        >
                                            {item.label}
                                        </MenuItem>
                                    ))}
                                </TextField>
                            ) : null}
                            <TextField
                                label="Credit Card Number"
                                name="number"
                                variant="outlined"
                                required
                                size='medium'
                                fullWidth
                                InputLabelProps={{shrink: true}}
                                value={creditCardNoCard}
                                onChange={(e) => setCreditCardNoCard(e.target.value)}
                                onFocus={(e) => setFocus(e.target.name)}
                                InputProps={{
                                    startAdornment: (
                                        <InputAdornment position="start">
                                            <CreditCardOutlinedIcon/>
                                        </InputAdornment>
                                    )
                                }}
                            />
                            <TextField
                                label="Full Name"
                                name="name"
                                fullWidth
                                variant="outlined"
                                required
                                size='medium'
                                InputLabelProps={{shrink: true}}
                                value={fullNameCard}
                                onChange={(e) => setFullNameCard(e.target.value)}
                                onFocus={(e) => setFocus(e.target.name)}
                                InputProps={{
                                    startAdornment: (
                                        <InputAdornment position="start">
                                            <BadgeOutlinedIcon/>
                                        </InputAdornment>
                                    )
                                }}
                            />
                            <Stack mb={3} direction={{xs: 'column', sm: 'row'}} spacing={2}>
                                <TextField
                                    label="Expiration Month"
                                    name="expiry"
                                    id="cardMonth"
                                    data-ref="cardDate"
                                    variant="outlined"
                                    required
                                    size='medium'
                                    fullWidth
                                    InputLabelProps={{shrink: true}}
                                    value={latestMonthCard}
                                    onChange={(e) => setLatestMonthCard(e.target.value)}
                                    onFocus={(e) => setFocus(e.target.name)}
                                    InputProps={{
                                        startAdornment: (
                                            <InputAdornment position="start">
                                                <EventBusyOutlinedIcon/>
                                            </InputAdornment>
                                        )
                                    }}
                                />
                                <TextField
                                    label="Expiration Year"
                                    name="expiryyear"
                                    id="cardYear"
                                    data-ref="cardDate"
                                    variant="outlined"
                                    required
                                    size='medium'
                                    fullWidth
                                    InputLabelProps={{shrink: true}}
                                    value={latestYearCard}
                                    onChange={(e) => setLatestYearCard(e.target.value)}
                                    onFocus={(e) => setFocus(e.target.name)}
                                    InputProps={{
                                        startAdornment: (
                                            <InputAdornment position="start">
                                                <EventBusyOutlinedIcon/>
                                            </InputAdornment>
                                        )
                                    }}
                                />
                            </Stack>
                            <TextField
                                label="CVC"
                                name="cvc"
                                variant="outlined"
                                required
                                size='medium'
                                fullWidth
                                InputLabelProps={{shrink: true}}
                                value={securityCodeCard}
                                onChange={(e) => setSecurityCodeCard(e.target.value)}
                                onFocus={(e) => setFocus(e.target.name)}
                                InputProps={{
                                    startAdornment: (
                                        <InputAdornment position="start">
                                            <GppGoodOutlinedIcon/>
                                        </InputAdornment>
                                    )
                                }}
                            />
                            <TextField
                                label="Amount"
                                name="amount"
                                variant="outlined"
                                fullWidth
                                required
                                size='medium'
                                InputLabelProps={{shrink: true}}
                                value={howMuchBalanceLoadedCard}
                                onChange={(e) => setHowMuchBalanceLoadedCard(e.target.value)}
                                onFocus={(e) => setFocus(e.target.name)}
                                InputProps={{
                                    startAdornment: (
                                        <InputAdornment position="start">
                                            <MonetizationOnOutlinedIcon/>
                                        </InputAdornment>
                                    )
                                }}
                            />
                            <Button
                                onClick={() => {
                                    setIsLoading(true)
                                    addBalance()
                                }}
                                fullWidth
                                size="large"
                                type="submit"
                                variant="contained"
                            >
                                {isLoading ? (
                                    <>
                                        <CircularProgress color="inherit" size={20}/>
                                    </>
                                ) : null}
                                Submit
                            </Button>
                        </Stack>
                    </Card>
                </Stack>
            </Container>
        </Page>
    );
}
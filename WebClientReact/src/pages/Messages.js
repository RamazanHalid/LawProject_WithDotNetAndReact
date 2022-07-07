// material
import {styled} from '@mui/material/styles';
import {
    Box,
    Button, Card, Checkbox,
    Container, IconButton, InputAdornment,
    Paper, Radio,
    Stack,
    Table, TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow, TextField,
    Typography
} from '@mui/material';
// layouts
// components
import Page from '../components/Page';
import {Icon} from "@iconify/react";
import messageSquareOutline from '@iconify/icons-eva/message-square-outline';
import RadioGroup from '@mui/material/RadioGroup';
import FormControlLabel from '@mui/material/FormControlLabel';
import FormControl from '@mui/material/FormControl';
import bookOpenOutline from '@iconify/icons-eva/book-open-outline';
import React, {useEffect, useState} from "react";
import {useNavigate} from "react-router-dom";
import MenuItem from "@mui/material/MenuItem";
import ClientsServise from "../services/clients.servise";
import PopupMessageService from "../services/popupMessage.service";
import {Global} from "../Global";
import LicenceUsersService from "../services/licenceUsers.service";
import CloseIcon from "@material-ui/icons/Close";
import SmsService from "../services/Sms.Service";
import EmailService from "../services/email.service";
import plusCircleOutline from '@iconify/icons-eva/plus-circle-outline';
import PersonOutlineOutlinedIcon from "@mui/icons-material/PersonOutlineOutlined";
import PeopleAltOutlinedIcon from '@mui/icons-material/PeopleAltOutlined';
import EmailOutlinedIcon from '@mui/icons-material/EmailOutlined';
import PhoneEnabledOutlinedIcon from '@mui/icons-material/PhoneEnabledOutlined';
import plusFill from "@iconify/icons-eva/plus-fill";
import navigation2Outline from '@iconify/icons-eva/navigation-2-outline';
import SmsTemplateService from "../services/smsTemplate.service";
import CircularProgress from "@mui/material/CircularProgress";
// ----------------------------------------------------------------------

export default function Messages() {
    const [clients, setClients] = useState([]);
    const [isEmail, setIsEmail] = useState(true);
    const [isSms, setIsSms] = useState(true);
    const [otherRecipient, setOtherRecipient] = useState([]);
    const [otherRecipientForCellphone, setOtherRecipientForCellphone] = useState([]);
    const [newCustomerIds, setNewCustomerIds] = useState([]);
    const [newMemberIds, setNewMemberIds] = useState([]);
    const [allClients, setAllClients] = useState(0);
    const [mailInfo, setMailInfo] = useState("");
    const [cellPhones, setCellPhone] = useState("");
    const [title, setTitle] = useState("");
    const [message, setMessage] = useState("");
    const [allUsers, setAllUsers] = useState([]);
    const [allMembers, setAllMembers] = useState(0);
    const [selectedRecipientType, setSelectedRecipientType] = useState(1);
    const smsTemplateService = new SmsTemplateService();
    const [allPostDrafts, setAllPOstDrafts] = useState([]);
    const [postDraftsId, setPostDraftsId] = useState(-1);
    const [time, setTime] = useState(true);

    const navigate = useNavigate();
    const clientsServise = new ClientsServise();
    const smsService = new SmsService();
    const emailService = new EmailService();
    const licenceUsersService = new LicenceUsersService();
    const popupMessageService = new PopupMessageService();
    const catchMessagee = Global.catchMessage;

    const sendMessage = () => {
        if (selectedRecipientType === 1) {
            if (isEmail) {
                emailService.sendEmailToCustomers({
                    ids: newCustomerIds,
                    title: title,
                    message: message
                }).then(result => {
                        if (result.data.Success) {
                            popupMessageService.AlertSuccessMessage(result.data.Message);
                        }
                    },
                    (error) => {
                        popupMessageService.AlertErrorMessage(error.response.data.Message);
                    }
                ).catch(() => {
                    popupMessageService.AlertErrorMessage(catchMessagee)
                })
            }
            if (isSms) {
                smsService.sendSmsToCustomers({
                    ids: newCustomerIds,
                    title: title,
                    message: message
                }).then(result => {
                        if (result.data.Success) {
                            popupMessageService.AlertSuccessMessage(result.data.Message);
                        }
                    },
                    (error) => {
                        popupMessageService.AlertErrorMessage(error.response.data.Message);
                    }
                ).catch(() => {
                    popupMessageService.AlertErrorMessage(catchMessagee)
                })
            }
        } else if (selectedRecipientType === 2) {
            if (isEmail) {
                emailService.sendEmailToMembers({
                    ids: newCustomerIds,
                    title: title,
                    message: message,
                }).then(result => {
                        if (result.data.Success) {
                            popupMessageService.AlertSuccessMessage(result.data.Message);
                        }
                    },
                    (error) => {
                        popupMessageService.AlertErrorMessage(error.response.data.Message);
                    }
                ).catch(() => {
                    popupMessageService.AlertErrorMessage(catchMessagee)
                })
            }
            if (isSms) {
                smsService.sendSmsToMembers({
                    ids: newCustomerIds,
                    title: title,
                    message: message
                }).then(result => {
                        if (result.data.Success) {
                            popupMessageService.AlertSuccessMessage(result.data.Message);
                        }
                    },
                    (error) => {
                        popupMessageService.AlertErrorMessage(error.response.data.Message);
                    }
                ).catch(() => {
                    popupMessageService.AlertErrorMessage(catchMessagee)
                })
            }
        } else if (selectedRecipientType === 3) {
            if (isEmail) {
                emailService.sendEmail({
                    tos: otherRecipient,
                    subject: title,
                    message: message,
                    contentFile: null
                }).then(result => {
                        if (result.data.Success) {
                            popupMessageService.AlertSuccessMessage(result.data.Message);
                        }
                    },
                    (error) => {
                        popupMessageService.AlertErrorMessage(error.response.data.Message);
                    }
                ).catch(() => {
                    popupMessageService.AlertErrorMessage(catchMessagee)
                })
            }
            if (isSms) {
                smsService.sendSms({
                    tos: otherRecipient,
                    title: title,
                    message: message
                }).then(result => {
                        if (result.data.Success) {
                            popupMessageService.AlertSuccessMessage(result.data.Message);
                        }
                    },
                    (error) => {
                        popupMessageService.AlertErrorMessage(error.response.data.Message);
                    }
                ).catch(() => {
                    popupMessageService.AlertErrorMessage(catchMessagee)
                })
            }
        }

    }


    const addSelectedRecipientToNewCustomerList = (value, label) => {
        newCustomerIds.push(value)
        otherRecipient.push(label)
        setNewCustomerIds([...newCustomerIds])
        setOtherRecipient([...otherRecipient])
    }

    const addSelectedRecipientToNewMemberList = (value, label) => {
        newMemberIds.push(value)
        otherRecipient.push(label)
        setNewMemberIds([...newMemberIds])
        setOtherRecipient([...otherRecipient])
    }

    const addSelectedRecipientToListForEmail = () => {
        otherRecipient.push(mailInfo)
        setOtherRecipient([...otherRecipient])
    }

    const addSelectedRecipientToListForCellphone = () => {
        otherRecipientForCellphone.push(cellPhones)
        setOtherRecipientForCellphone([...otherRecipientForCellphone])
    }

    const removeSelectedRecipientToList = (selectedEmail) => {
        console.log(selectedEmail)
        let newList = [...otherRecipient]
        const index = newList.indexOf(selectedEmail);
        if (index > -1) {
            newList.splice(index, 1);
        }
        setOtherRecipient(newList)
    }

    const removeSelectedRecipientToListForCellphone = (selectedCellphone) => {
        console.log(selectedCellphone)
        let newList = [...otherRecipientForCellphone]
        const index = newList.indexOf(selectedCellphone);
        if (index > -1) {
            newList.splice(index, 1);
        }
        setOtherRecipientForCellphone(newList)
    }

    const getAllCustomers = () => {
        clientsServise
            .getAll()
            .then(
                (response) => {
                    setClients(response.data.Data);
                    const CaseTypesFromApi = response.data.Data;
                    const list = [];
                    CaseTypesFromApi.forEach((item) => {
                        list.push({
                            value: item.CustomerId,
                            label: item.CustomerName,
                            key: item.CustomerName
                        });
                    });
                    setAllClients(list[0].value)
                    setClients(list);
                },
                (error) => {
                    popupMessageService.AlertErrorMessage(error.response.data.Message);
                }
            )
            .catch(() => {
                popupMessageService.AlertErrorMessage(catchMessagee)
            });
    };
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
                    setAllMembers(list[0].value)
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

    const getAllPostDrafts = () => {
        smsTemplateService
            .getAll()
            .then(
                (response) => {
                    setAllPOstDrafts(response.data.Data);
                    const CreditCardReminderFromApi = response.data.Data;
                    const list = [];
                    CreditCardReminderFromApi.forEach((item) => {
                        list.push({
                            value: item.SmsTemplateId,
                            label: item.SmsHeader,
                            key: item.SmsHeader
                        });
                    });
                    setAllPOstDrafts(list);

                },
                (error) => {
                    popupMessageService.AlertErrorMessage(error.response.data.Message);
                }
            )
            .catch(() => {
                popupMessageService.AlertErrorMessage(catchMessagee)
            });
    };

    function getByIdPostDraft(id) {
        smsTemplateService.getById(id).then(result => {
            if (result.data.Success) {
                let sms = result.data.Data
                setTitle(sms.SmsHeader)
                setMessage(sms.Message)
            }
        })
    }

    function handlePostDraftChange(TatId) {
        getByIdPostDraft(TatId)
        setPostDraftsId(TatId)
    }

    useEffect(() => {
        getAllCustomers();
        getAllUsers();
        getAllPostDrafts();
        setTime(false)
    }, [])

    return (
        <Page title="Messages | MediLaw">
            {time === true ?
                <Stack sx={{color: 'grey.500', padding: 30}} spacing={2} direction="row"
                       justifyContent='center' alignSelf='center' left='50%'>
                    <CircularProgress color="inherit"/>
                </Stack>
                :
                <Container>
                    <Stack direction="row" alignItems="center" justifyContent="space-between" mb={3}>
                        <Typography variant="h4" gutterBottom>
                            Messages
                        </Typography>
                        <Stack direction="row">
                            <Button onClick={() => {
                                navigate('/dashboard/Messages/postDrafts')
                            }} sx={{right: 20}} variant="contained" startIcon={<Icon icon={bookOpenOutline}/>}>
                                Post Drafts
                            </Button>
                            <Button onClick={() => {
                                navigate('/dashboard/Messages/sentMessages')
                            }} variant="contained" startIcon={<Icon icon={messageSquareOutline}/>}>
                                Sent Messages
                            </Button>
                        </Stack>
                    </Stack>
                    <Card justifyContent="flex-start" sx={{padding: 6, maxWidth: 830, marginLeft: 14, marginTop: 7}}>
                        <Stack mb={3}>
                            {allPostDrafts.length > 0 ? (
                                <Box sx={{minWidth: 730, maxWidth: 730}}>
                                    <TextField
                                        select
                                        label="Post Drafts (Optional)"
                                        fullWidth
                                        value={postDraftsId}
                                        onChange={(e) => handlePostDraftChange(e.target.value)}
                                    >
                                        <MenuItem
                                            key={Math.random().toString(36).substr(2, 9)}
                                            value={-1} onClick={() => {
                                            setTitle("")
                                            setMessage("")
                                        }}>None</MenuItem>
                                        {allPostDrafts.map((item) => (
                                            <MenuItem
                                                key={Math.random().toString(36).substr(2, 9)}
                                                value={item.value}
                                            >
                                                {item.label}
                                            </MenuItem>
                                        ))}
                                    </TextField>
                                </Box>
                            ) : null}
                        </Stack>
                        <Stack mb={3}>
                            <Box sx={{minWidth: 730, maxWidth: 730}}>
                                <FormControl fullWidth>
                                    <TextField
                                        label="Title"
                                        value={title}
                                        onChange={(e) => setTitle(e.target.value)}
                                    >
                                    </TextField>
                                </FormControl>
                            </Box>
                        </Stack>
                        <Stack mb={3} justifyContent="space-around">
                            <Box sx={{minWidth: 730, maxWidth: 730}}>
                                <FormControl fullWidth>
                                    <TextField
                                        type='text'
                                        id="outlined-multiline-static"
                                        multiline
                                        rows={5}
                                        value={message}
                                        onChange={(e) => setMessage(e.target.value)}
                                        label="Message"

                                    />
                                </FormControl>
                            </Box>
                        </Stack>
                        <Stack mb={0} flexDirection="row" alignItems="center" justifyContent="flex-start">
                            <Stack mb={7} justifyContent="space-around">
                                <Typography variant="body1" gutterBottom mb={3}>
                                    Select Recipient
                                </Typography>
                                <RadioGroup
                                    sx={{flexDirection: "row"}}
                                    aria-labelledby="demo-radio-buttons-group-label"
                                    defaultValue="1"
                                    name="radio-buttons-group"
                                    onChange={(e) => {
                                        setSelectedRecipientType(parseInt(e.target.value))
                                    }}
                                >
                                    <FormControlLabel onClick={() => {
                                        setOtherRecipient([])
                                        setCellPhone("")
                                        setMailInfo("")
                                    }} value="1" control={<Radio/>} label="To Client"/>
                                    <FormControlLabel onClick={() => {
                                        setOtherRecipient([])
                                        setCellPhone("")
                                        setMailInfo("")
                                    }} value="2" control={<Radio/>} label="To Member"/>
                                    <FormControlLabel onClick={() => {
                                        setOtherRecipient([])
                                    }} value="3" control={<Radio/>} label="Other"/>
                                </RadioGroup>
                            </Stack>
                            <Stack mb={5} ml={10} justifyContent="space-around">
                                <Typography variant="body1" gutterBottom mb={4}>
                                    Email
                                </Typography>
                                <Checkbox
                                    sx={{bottom: 10}}
                                    checked={isEmail}
                                    onChange={(e) => setIsEmail(e.target.checked)}
                                    inputProps={{'aria-label': 'controlled'}}
                                />
                            </Stack>
                            <Stack mb={5} ml={3} justifyContent="space-around">
                                <Typography variant="body1" gutterBottom mb={4}>
                                    Sms
                                </Typography>
                                <Checkbox
                                    sx={{bottom: 10}}
                                    checked={isSms}
                                    onChange={(e) => setIsSms(e.target.checked)}
                                    inputProps={{'aria-label': 'controlled'}}
                                />
                            </Stack>
                        </Stack>
                        <Stack mb={3} flexDirection="row" alignItems="center" justifyContent="flex-start">
                            {selectedRecipientType === 1 ?
                                <Stack mb={3} justifyContent="space-around">
                                    <>
                                        {clients.length > 0 ? (
                                            <Stack flexDirection='row' justifyContent='space-between'>
                                                <Box sx={{maxWidth: 400, minWidth: 400}}>
                                                    <FormControl fullWidth size="small">
                                                        <TextField
                                                            select
                                                            size='small'
                                                            label="Clients"
                                                            value={allClients}
                                                            key={Math.random().toString(36).substr(2, 9)}
                                                            onChange={(event) => setAllClients(event.target.value)}
                                                            InputProps={{
                                                                startAdornment: (
                                                                    <InputAdornment position="start">
                                                                        <PersonOutlineOutlinedIcon/>
                                                                    </InputAdornment>
                                                                )
                                                            }}
                                                        >
                                                            {clients.map((item) => (
                                                                <MenuItem
                                                                    key={Math.random().toString(36).substr(2, 9)}
                                                                    value={item.value}
                                                                >
                                                                    {item.label}
                                                                    <IconButton
                                                                        onClick={() => addSelectedRecipientToNewCustomerList(item.value, item.label)}>
                                                                        <Icon icon={plusCircleOutline}/>
                                                                    </IconButton>
                                                                </MenuItem>
                                                            ))}
                                                        </TextField>
                                                    </FormControl>
                                                </Box>
                                            </Stack>

                                        ) : null}
                                    </>
                                </Stack>
                                : null}

                            {selectedRecipientType === 2 ?
                                <Stack mb={3} justifyContent="space-around">
                                    <>
                                        {allUsers.length > 0 ? (
                                            <Box sx={{maxWidth: 400, minWidth: 400}}>
                                                <FormControl fullWidth>
                                                    <TextField
                                                        select
                                                        size='small'
                                                        label="Members"
                                                        value={allMembers}
                                                        key={Math.random().toString(36).substr(2, 9)}
                                                        onChange={(event) => setAllMembers(event.target.value)}
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
                                                                <IconButton
                                                                    onClick={() => addSelectedRecipientToNewMemberList(item.value, item.label)}>
                                                                    <Icon icon={plusCircleOutline}/>
                                                                </IconButton>
                                                            </MenuItem>
                                                        ))}
                                                    </TextField>
                                                </FormControl>
                                            </Box>
                                        ) : null}
                                    </>
                                </Stack>
                                : null}
                        {selectedRecipientType === 3 ?
                            <>
                                <Stack flexDirection='row' mb={3} mr={2} justifyContent="space-around">
                                    {isEmail ?
                                        <>
                                            <Box sx={{maxWidth: 265, minWidth: 265}}>
                                                <FormControl fullWidth>
                                                    <TextField
                                                        type="email"
                                                        label="Emails"
                                                        value={mailInfo}
                                                        onChange={(e) => setMailInfo(e.target.value)}
                                                        InputProps={{
                                                            startAdornment: (
                                                                <InputAdornment position="start">
                                                                    <EmailOutlinedIcon/>
                                                                </InputAdornment>
                                                            )
                                                        }}
                                                    >
                                                    </TextField>
                                                </FormControl>
                                            </Box>
                                            <Button onClick={addSelectedRecipientToListForEmail}
                                                    variant="contained"
                                                    sx={{marginLeft:1}}
                                                    startIcon={<Icon icon={plusFill}/>}>
                                                Add
                                            </Button>
                                        </>
                                        : null}
                                    {isSms ?
                                        <>
                                            <Box sx={{maxWidth: 265, minWidth: 265, marginLeft:2}}>
                                                <FormControl fullWidth>
                                                    <TextField
                                                        type={"number"}
                                                        label="Cell Phones"
                                                        value={cellPhones}
                                                        onChange={(e) => setCellPhone(e.target.value)}
                                                        InputProps={{
                                                            startAdornment: (
                                                                <InputAdornment position="start">
                                                                    <PhoneEnabledOutlinedIcon/>
                                                                </InputAdornment>
                                                            )
                                                        }}
                                                    >
                                                    </TextField>
                                                </FormControl>
                                            </Box>
                                            <Button onClick={addSelectedRecipientToListForCellphone}
                                                    variant="contained"
                                                    sx={{marginLeft:1}}
                                                    startIcon={<Icon icon={plusFill}/>}>
                                                Add
                                            </Button>
                                        </>
                                        : null}

                                </Stack>
                            </>
                            : null}
                        </Stack>
                        {otherRecipient.length > 0 ?
                            <Card sx={{
                                minWidth: 400,
                                maxWidth: 400,
                                minHeight: 50,
                                borderRadius: 1,
                                padding: 2,
                                paddingLeft: 4,
                                marginBottom: 4,
                                marginTop: 0
                            }} mb={2}>
                                {otherRecipient.map((row) => (
                                    <Stack flexDirection='row' justifyContent='space-between' pt={1}>
                                        <Typography>
                                            {row}
                                        </Typography>
                                        <IconButton sx={{bottom: 4}}>
                                            <CloseIcon onClick={() => removeSelectedRecipientToList(row)}/>
                                        </IconButton>
                                    </Stack>
                                ))}
                            </Card>
                            : null}
                        {otherRecipientForCellphone.length > 0 ?
                            <Card sx={{
                                minWidth: 400,
                                maxWidth: 400,
                                minHeight: 50,
                                borderRadius: 1,
                                padding: 2,
                                paddingLeft: 4,
                                marginBottom: 4,
                                marginTop: 0
                            }} mb={2}>
                                {otherRecipientForCellphone.map((row) => (
                                    <Stack flexDirection='row' justifyContent='space-between' pt={1}>
                                        <Typography>
                                            {row}
                                        </Typography>
                                        <IconButton sx={{bottom: 4}}>
                                            <CloseIcon onClick={() => removeSelectedRecipientToListForCellphone(row)}/>
                                        </IconButton>
                                    </Stack>
                                ))}
                            </Card>
                            : null}
                        <Button sx={{width: '15%'}} onClick={sendMessage} fullWidth
                                size="large"
                                type="submit"
                                variant="contained"
                                startIcon={<Icon icon={navigation2Outline}/>}>
                            Send
                        </Button>
                    </Card>
                </Container>
            }
        </Page>
    );
}

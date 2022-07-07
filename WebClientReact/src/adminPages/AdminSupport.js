// material
import {styled} from '@mui/material/styles';
import {
    Avatar,
    Box,
    Button,
    Card,
    Container, Divider,
    Grid,
    IconButton,
    InputAdornment,
    Paper,
    Stack, StepButton,
    Table,
    TableCell,
    TableContainer,
    TableRow,
    TextField,
    Typography,

} from '@mui/material';
// components
import Page from '../components/Page';
import React, {useEffect, useState, useRef} from "react";
import {Icon} from "@iconify/react";
import navigation2Outline from "@iconify/icons-eva/navigation-2-outline";
import PopupMessageService from "../services/popupMessage.service";
import {Global} from "../Global";
import ChatSupportService from "../services/chatSupport.service";
import CircularProgress from "@mui/material/CircularProgress";
import CardContent from "@mui/material/CardContent";
import baselineDoneAll from '@iconify/icons-ic/baseline-done-all';
import {format} from "date-fns";
import ReplayIcon from '@mui/icons-material/Replay';
import {green} from '@mui/material/colors';
import Fab from '@mui/material/Fab';
import CheckIcon from '@mui/icons-material/Check';
import account from "../_mocks_/account";
import Badge from '@mui/material/Badge';
import bellOutline from "@iconify/icons-eva/bell-outline";

// ----------------------------------------------------------------------

const RootStyle = styled(Page)(({theme}) => ({
    [theme.breakpoints.up('md')]: {
        display: 'flex',
    }
}));
const AccountStyle = styled('div')(({theme}) => ({
    display: 'flex',
    alignItems: 'center',
    padding: theme.spacing(2, 2.5),
    borderRadius: theme.shape.borderRadius,
    width: 110,
    height: 65
}));

const AccountStyle2 = styled('div')(({ theme }) => ({
    display: 'flex',
    alignItems: 'center',
    padding: theme.spacing(2, 2.5),
    borderRadius: theme.shape.borderRadius,
    width: 260,
    height:55,
    marginLeft: 15,
    marginBottom: 5
}));

const AccountStyle3 = styled('div')(({ theme }) => ({
    display: 'flex',
    alignItems: 'center',
    padding: theme.spacing(2, 2.5),
    borderRadius: theme.shape.borderRadius,
    width: 260,
    height:55,
    marginLeft: 15,
    marginBottom: 5,
    backgroundColor: '#e9eff5'
}));
// ----------------------------------------------------------------------

function MailIcon(props: { color: string }) {
    return null;
}

export default function Support() {

    const popupMessageService = new PopupMessageService();
    const chatSupportService = new ChatSupportService();
    const catchMessagee = Global.catchMessage;
    const [message, setMessage] = useState("");
    const [supportMessages, setSupportMessages] = useState([]);
    const [userToLeft, setUsresToLeft] = useState([]);
    const [isLoading, setIsLoading] = useState(true);
    const [loading, setLoading] = React.useState(false);
    const [success, setSuccess] = React.useState(false);
    const [userId, setUserId] = React.useState(0);
    const [licenceId, setLicenceId] = React.useState(0);
    const [selectedFullName, setSelectedFullName] = React.useState("");
    const timer = React.useRef();

    const getAllSupportMessages = (userId, licenceId) => {
        chatSupportService.getAllMessegaAsAdmin(userId, licenceId).then(
            (result) => {
                if (result.data.Success) {
                    setSupportMessages(result.data.Data)
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

    function addNewRecord() {
        let obj = {
            licenceId: licenceId,
            userId: userId,
            message: message
        }
        let re = chatSupportService.addMessegaAsAdmin(obj)
        re.then((result) => {
                if (result.data.Success) {
                    getAllSupportMessages(userId, licenceId)
                    setMessage("")
                }
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    }

    const makeTheMessageRead = (userId, licenceId) => {
        chatSupportService.makeItReadAsAdmin(userId, licenceId).then(
            (result) => {
                if (result.data.Success) {
                    getAllSupportMessages(userId, licenceId)
                }
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    };

    const listAllUsersToLeft = () => {
        chatSupportService.listUsersToSideBar().then(
            (result) => {
                if (result.data.Success) {
                    setUsresToLeft(result.data.Data)
                }
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    };

    const messageEl = useRef(null);

    const buttonSx = {
        ...(success && {
            bgcolor: green[500],
            '&:hover': {
                bgcolor: green[700],
            },
        }),
    };

    React.useEffect(() => {
        return () => {
            clearTimeout(timer.current);
        };
    }, []);

    const handleButtonClick = () => {
        getAllSupportMessages(userId, licenceId)
        if (!loading) {
            setSuccess(false);
            setLoading(true);
            timer.current = window.setTimeout(() => {
                setSuccess(true);
                setLoading(false);
            }, 2000);
        }
    };

    const getSelectedLicenceMessage = (userId, licenceId, fullName) => {
        setLicenceId(licenceId)
        setUserId(userId)
        getAllSupportMessages(userId, licenceId)
        setSelectedFullName(fullName)
    }
    useEffect(() => {
        makeTheMessageRead(userId, licenceId)
        listAllUsersToLeft()
        if (userId > 0 && licenceId > 0) {
            if (messageEl) {
                messageEl.current.addEventListener('DOMNodeInserted', event => {
                    const {currentTarget: target} = event;
                    target.scroll({top: target.scrollHeight, behavior: 'smooth'});
                });
            }
        }
    }, []);

    return (
        <RootStyle title="Support | MediLaw">
            <Container>
                <Stack direction="row" alignItems="center" justifyContent="space-between" mb={4}>
                    <Typography variant="h4" gutterBottom>
                        Support
                    </Typography>
                    <Box sx={{display: 'flex', alignItems: 'center'}}>
                        <Box sx={{m: 1, position: 'relative'}}>
                            <Fab
                                aria-label="save"
                                color="primary"
                                sx={buttonSx}
                                onClick={handleButtonClick}
                            >
                                {success ? <CheckIcon/> : <ReplayIcon/>}
                            </Fab>
                            {loading && (
                                <CircularProgress
                                    size={68}
                                    sx={{
                                        color: green[500],
                                        position: 'absolute',
                                        top: -6,
                                        left: -6,
                                        zIndex: 1,
                                    }}
                                />
                            )}
                        </Box>
                    </Box>
                </Stack>
                <Stack flexDirection='row' alignItems='space-between'>
                    <Card sx={{minWidth: 290, maxWidth: 300, paddingTop: 2, marginLeft: 1}}>
                        {userToLeft.length > 0 ? (
                            <>
                                {userToLeft.map((row) => (
                                    <>
                                        {row.LicenceId === licenceId ?
                                            <IconButton disableRipple sx={{ ml: 0, "&.MuiButtonBase-root:hover": {bgcolor: "transparent"}}}>
                                            <AccountStyle3 key={row.LicenceId} onClick={() => getSelectedLicenceMessage(row.UserId, row.LicenceId, row.UserFullName +  '-' + row.LicenceProfileName)} sx={{ flexDirection: 'row', p: 1.6, border: '1px dashed #b1b9be', '&:hover': {backgroundColor: '#F4F6F8', boxShadow: 'none'}}}>
                                                <Avatar
                                                    src={'https://webapi.emlakofisimden.com/' + row.UserProfileImage}
                                                    alt="photoURL"/>
                                                <Typography gutterBottom  color='#1d4d9f' sx={{paddingLeft: 1, paddingTop: 1, fontSize: 12}}>
                                                    {row.LicenceProfileName} -
                                                </Typography>
                                                <Typography gutterBottom color='#1d4d9f' sx={{paddingLeft: 0.5, paddingTop: 1, fontSize: 12}}>
                                                    {row.UserFullName}
                                                </Typography>
                                                    <Typography gutterBottom color='#1d4d9f' sx={{marginRight: 4, paddingTop: 0.6,position: 'absolute', right: '0'}}>
                                                        <Badge badgeContent={row.MessageCount} color="primary">
                                                            <MailIcon color="action" />
                                                        </Badge>
                                                    </Typography>
                                            </AccountStyle3>
                                            </IconButton>
                                            :
                                            <IconButton disableRipple sx={{ ml: 0, "&.MuiButtonBase-root:hover": {bgcolor: "transparent"}}}>
                                            <AccountStyle2 key={row.LicenceId} onClick={() => getSelectedLicenceMessage(row.UserId, row.LicenceId,row.UserFullName +  '-' + row.LicenceProfileName)} sx={{ flexDirection: 'row', p: 1.6, border: '1px dashed #b1b9be', '&:hover': {backgroundColor: '#F4F6F8', boxShadow: 'none'}}}>
                                            <Avatar
                                                    src={'https://webapi.emlakofisimden.com/' + row.UserProfileImage}
                                                    alt="photoURL"/>
                                                <Typography gutterBottom sx={{paddingLeft: 1, paddingTop: 1, fontSize: 12}}>
                                                    {row.LicenceProfileName} -
                                                </Typography>
                                                <Typography gutterBottom sx={{paddingLeft: 0.5, paddingTop: 1, fontSize: 12}}>
                                                    {row.UserFullName}
                                                </Typography>
                                                <Typography gutterBottom sx={{marginRight: 4, paddingTop: 0.6,position: 'absolute', right: '0'}}>
                                                    <Badge badgeContent={row.MessageCount} color="primary">
                                                        <MailIcon color="action" />
                                                    </Badge>
                                                </Typography>
                                            </AccountStyle2>
                                            </IconButton>
                                        }
                                    </>
                                ))}
                            </>
                        ) : null}
                    </Card>
                    {userId > 0 && licenceId > 0 ?
                        <Card sx={{minWidth: 450, maxWidth: 750, marginLeft: 2, paddingTop: 3}}>
                            <Stack flexDirection='row' alignItems='space-between'>
                                <Avatar src={account.photoURL} alt="photoURL" sx={{marginLeft: 4, marginTop: -1}}/>
                                <Typography variant="h6" gutterBottom
                                            sx={{paddingBottom: 1.5, paddingLeft: 2.4, color: 'primary'}}>
                                    {selectedFullName}
                                </Typography>
                            </Stack>
                            <Box ref={messageEl} justifyContent="center" sx={{
                                paddingLeft: 3,
                                paddingRight: 3,
                                paddingTop: 3,
                                paddingBottom: 3,
                                marginLeft: 0,
                                maxHeight: 375,
                                overflow: "hidden",
                                overflowY: "scroll",
                                p: 1, borderTop: '1px dashed #b1b9be'
                            }}>
                                <>
                                    {isLoading === true ?
                                        <Stack sx={{color: 'grey.500', paddingLeft: 0, paddingTop: 3}} spacing={2}
                                               direction="row"
                                               justifyContent='center' alignSelf='center' left='50%'>
                                            <CircularProgress color="inherit"/>
                                        </Stack>
                                        :
                                        <>
                                            {supportMessages.length > 0 ? (
                                                <>
                                                    {supportMessages.map((row) => (
                                                        <>
                                                            {row.IsAnswer == true ?
                                                                <Card sx={{
                                                                    maxWidth: '40%',
                                                                    minWidth: '40%',
                                                                    marginTop: 2.2,
                                                                    marginRight: 0,
                                                                    backgroundColor: '#ebf2ff',
                                                                    marginLeft: 53,
                                                                    maxHeight: 75,
                                                                    boxShadow: 7

                                                                }}>
                                                                    <CardContent>
                                                                        <Stack flexDirection='row'>
                                                                            <Typography gutterBottom fontSize={12}
                                                                                        component="div"
                                                                                        key={row.ChatSupportId}
                                                                                        sx={{paddingTop: -4}}>
                                                                                {row.Message}
                                                                            </Typography>
                                                                            {row.DoesItRead == true ?
                                                                                <Stack position='absolute' right='0'
                                                                                       mr={3}
                                                                                       mt={2.5}>
                                                                                    <Icon icon={baselineDoneAll}
                                                                                          width={20}
                                                                                          height={20}
                                                                                          color={'#4fb6ec'}/>
                                                                                </Stack>
                                                                                : <Stack position='absolute' right='0'
                                                                                         mr={3}
                                                                                         mt={2.5}>
                                                                                    <Icon icon={baselineDoneAll}
                                                                                          width={20}
                                                                                          height={20}
                                                                                          color={'#a9a9a9'}/>
                                                                                </Stack>}
                                                                        </Stack>
                                                                        <Typography gutterBottom fontSize={10}
                                                                                    component="div" color='gray'
                                                                                    sx={{paddingLeft: 14}}>
                                                                            {format(new Date(row.Date), 'dd/MM/yyyy kk:mm')}
                                                                        </Typography>
                                                                    </CardContent>
                                                                </Card>
                                                                :
                                                                <Card sx={{
                                                                    maxWidth: '45%',
                                                                    minWidth: '50%',
                                                                    marginTop: 2.2,
                                                                    marginLeft: 2.5,
                                                                    backgroundColor: '#fff',
                                                                    maxHeight: 75,
                                                                    boxShadow: 7
                                                                }}>
                                                                    <CardContent>
                                                                        <Stack flexDirection='row'>
                                                                            <Typography gutterBottom fontSize={12}
                                                                                        component="div"
                                                                                        key={row.ChatSupportId}>
                                                                                {row.Message}
                                                                            </Typography>
                                                                        </Stack>
                                                                        <Typography gutterBottom fontSize={10}
                                                                                    component="div" color='gray'>
                                                                            {format(new Date(row.Date), 'dd/MM/yyyy kk:mm')}
                                                                        </Typography>
                                                                    </CardContent>
                                                                </Card>
                                                            }
                                                        </>
                                                    ))}
                                                </>
                                            ) : (
                                                <card sx={{width: '40%'}}>
                                                    <img src="/static/illustrations/no.png" alt="login"/>
                                                    <Typography variant="h3" gutterBottom textAlign='center'
                                                                color='#a9a9a9'>No
                                                        Data
                                                        Found</Typography>
                                                </card>
                                            )}
                                        </>
                                    }
                                </>
                            </Box>
                            <Stack padding={2.5} mb={0} mt={0} flexDirection='row' spacing={2}>
                                <Box sx={{
                                    maxWidth: 700,
                                    minWidth: 700,
                                    p: 1,
                                    border: '1px dashed #b1b9be',
                                    borderRadius: 1,
                                }}>
                                    <TextField
                                        autoFocus
                                        variant="standard" // <== changed this
                                        fullWidth
                                        size='small'
                                        multiline
                                        placeholder="Type a message"
                                        value={message}
                                        onChange={(event) => setMessage(event.target.value)}
                                        InputProps={{
                                            disableUnderline: true,
                                            style: {
                                                height: "55px",
                                                paddingLeft: 10
                                            }
                                        }}
                                    />

                                    <IconButton onClick={() => addNewRecord()} disableRipple
                                                sx={{
                                                    position: 'absolute',
                                                    right: '0',
                                                    mr: -1.5,
                                                    mt: -1.7,
                                                    "&.MuiButtonBase-root:hover": {bgcolor: "transparent"}
                                                }}>
                                        <AccountStyle sx={{
                                            p: 3,
                                            borderLeft: '1px dashed #b1b9be',
                                            borderRadius: 0,
                                            '&:hover': {boxShadow: 'none'}
                                        }}>
                                            <Icon icon={navigation2Outline} width={33} height={33} color='#a19f9f'/>
                                        </AccountStyle>
                                    </IconButton>
                                </Box>
                            </Stack>
                        </Card>
                        : <Card sx={{minWidth: 450, maxWidth: 750, marginLeft: 2, paddingTop: 0}}>
                            <img src="/static/illustrations/no.png" alt="login"/>
                            <Typography variant="h3" gutterBottom textAlign='center' color='#a9a9a9'>No Data Found</Typography>
                        </Card>}
                </Stack>
            </Container>
        </RootStyle>
    );
}

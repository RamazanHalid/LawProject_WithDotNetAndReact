import {noCase} from 'change-case';
import {useEffect, useRef, useState} from 'react';
import {Link as RouterLink} from 'react-router-dom';
import {format} from 'date-fns';
import {Icon} from '@iconify/react';
import bellOutline from '@iconify/icons-eva/bell-outline';
import clockFill from '@iconify/icons-eva/clock-fill';
import doneAllFill from '@iconify/icons-eva/done-all-fill';
// material
import {alpha, styled} from '@mui/material/styles';
import {
    Box,
    List,
    Badge,
    Button,
    Avatar,
    Tooltip,
    Divider,
    IconButton,
    Typography,
    ListItemText,
    ListSubheader,
    ListItemAvatar,
    ListItemButton, Stack
} from '@mui/material';
// components
import Scrollbar from '../../components/Scrollbar';
import MenuPopover from '../../components/MenuPopover';
import {Global} from "../../Global";
import PopupMessageService from "../../services/popupMessage.service";
import NotificationsService from "../../services/notifications.service";
import account from "../../_mocks_/account";
import trash2Outline from '@iconify/icons-eva/trash-2-outline';
// ----------------------------------------------------------------------

export default function AdminNotificationsPopover() {
    const catchMessagee = Global.catchMessage;
    const popupMessageService = new PopupMessageService();
    const notificationsService = new NotificationsService();
    const anchorRef = useRef(null);
    const [open, setOpen] = useState(false);
    const [countNotification, setCountNotification] = useState(0);
    const [allNotifications, setAllNotifications] = useState([]);
    const totalUnRead = allNotifications.filter((item) => item.isUnRead === true).length;

    const handleOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    const getAllNotifications = () => {
        notificationsService.getAll().then(
            (result) => {
                if (result.data.Success) {
                    setAllNotifications(result.data.Data)
                }
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    };
    const makeItAllRead = () => {
        notificationsService.makeAllItRead().then(
            (result) => {
                if (result.data.Success) {
                    getAllNotifications()
                    getCountNotification()
                }
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    };
    const deleteAll = () => {
        notificationsService.deleteAll().then(
            (result) => {
                if (result.data.Success) {
                    getAllNotifications()
                    getCountNotification()
                }
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    };
    const getCountNotification = () => {
        notificationsService.getCount().then(
            (result) => {
                if (result.data.Success) {
                    setCountNotification(result.data.Data)
                }
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    };
    function deleteNotification(id) {
        notificationsService.delete(id).then(result => {
                if (result.data.Success) {
                    getAllNotifications()
                    getCountNotification()
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

    useEffect(() => {
        getAllNotifications();
        getCountNotification();
    }, [])


    return (
        <>
            <IconButton
                ref={anchorRef}
                size="large"
                color={open ? 'primary' : 'default'}
                onClick={handleOpen}
                sx={{
                    ...(open && {
                        bgcolor: (theme) => alpha(theme.palette.primary.main, theme.palette.action.focusOpacity)
                    })
                }}
            >
                <Badge badgeContent={countNotification} color="error">
                    <Icon icon={bellOutline} width={26} height={26} onClick={makeItAllRead}/>
                </Badge>
            </IconButton>

            <MenuPopover
                open={open}
                onClose={handleClose}
                anchorEl={anchorRef.current}
                sx={{width: 360}}
            >
                <Box sx={{display: 'flex', alignItems: 'center', py: 2, px: 2.5}}>
                    <Box sx={{flexGrow: 1}}>
                        <Typography variant="subtitle1">Notifications</Typography>
                        <Typography variant="body2" sx={{color: 'text.secondary'}}>
                            You have {countNotification} unread messages
                        </Typography>
                    </Box>

                    {countNotification > 0 && (
                        <Tooltip title=" Mark all as read">
                            <IconButton color="primary" >
                                <Icon icon={doneAllFill} width={20} height={20}/>
                            </IconButton>
                        </Tooltip>
                    )}
                </Box>

                <Divider/>

                <Scrollbar sx={{height: {xs: 340, sm: 'auto'}}}>
                    <List
                        disablePadding
                        subheader={
                            <ListSubheader disableSticky sx={{py: 1, px: 2.5, typography: 'overline'}}>
                                New
                            </ListSubheader>
                        }
                    >
                        {allNotifications.length > 0 ? (
                            <>
                                {allNotifications.map((row) => (
                                    <Stack flexDirection='row'>
                                        <ListItemButton
                                            to="#"
                                            disableGutters
                                            component={RouterLink}
                                            sx={{
                                                py: 1.5,
                                                px: 2.5,
                                                mt: '1px',
                                                ...(row.isUnRead && {
                                                    bgcolor: 'action.selected'
                                                })
                                            }}
                                            key={row.NotificationId}
                                        >
                                            <ListItemAvatar>
                                                <Avatar src={account.photoURL} alt="photoURL"/>
                                            </ListItemAvatar>
                                            <Stack flexDirection='column'>
                                                <Typography variant="subtitle2">
                                                    {row.Title}
                                                    <Typography component="span" variant="body2"
                                                                sx={{color: 'text.secondary'}}>
                                                        &nbsp; {noCase(row.Content)}
                                                    </Typography>
                                                </Typography>
                                                <ListItemText
                                                    secondary={
                                                        <Typography
                                                            variant="caption"
                                                            sx={{
                                                                mt: 0.5,
                                                                display: 'flex',
                                                                alignItems: 'center',
                                                                color: 'text.disabled'
                                                            }}
                                                        >
                                                            <Box component={Icon} icon={clockFill}
                                                                 sx={{mr: 0.5, width: 16, height: 16}}/>
                                                            {format(new Date(row.Date), 'dd/MM/yyyy kk:mm')}
                                                        </Typography>
                                                    }
                                                />
                                            </Stack>
                                        </ListItemButton>
                                        <IconButton onClick={()=> deleteNotification(row.NotificationId)} sx={{ mr: 2, color: 'red', width: 60 , height: 60, mt: 0.6}}>
                                            <Icon icon={trash2Outline} />
                                        </IconButton>
                                    </Stack>

                                ))}
                            </>
                        ) : null}
                    </List>
                    <Divider/>
                    <Box sx={{p: 1}}>
                        <Button onClick={()=> deleteAll()} fullWidth disableRipple component={RouterLink} to="#">
                            Delete All
                        </Button>
                    </Box>
                </Scrollbar>
            </MenuPopover>
        </>
    );
}

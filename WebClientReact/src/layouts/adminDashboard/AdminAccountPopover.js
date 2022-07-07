import { Icon } from '@iconify/react';
import { useRef, useState } from 'react';
import homeOutline from '@iconify/icons-eva/home-outline';
import settingsOutline from '@iconify/icons-eva/settings-outline';
import { Link as RouterLink, useNavigate } from 'react-router-dom';
// material
import { alpha } from '@mui/material/styles';
import {Button, Box, Divider, MenuItem, Typography, IconButton, Avatar} from '@mui/material';
// components
import MenuPopover from '../../components/MenuPopover';
//
import account from '../../_mocks_/account';
import AuthService from '../../services/auth.service';
import npmOutline from "@iconify/icons-eva/npm-outline";

// ----------------------------------------------------------------------

const MENU_OPTIONS = [
    {
        label: 'Home',
        icon: homeOutline,
        linkTo: '/admindashboard/admin'
    },
    {
        label: 'Settings',
        icon: settingsOutline,
        linkTo: '#'
    },
    {
        label: 'Medilaw Panel',
        icon: npmOutline,
        linkTo: '/dashboard/app'
    }
];

// ----------------------------------------------------------------------

export default function AdminAccountPopover() {
    const anchorRef = useRef(null);
    const [open, setOpen] = useState(false);
    const navigate = useNavigate();
    const authService = new AuthService()


    const handleOpen = () => {
        setOpen(true);
    };
    const handleClose = () => {
        setOpen(false);
    };
    const Logout = () => {
        authService.logout();
        navigate('/login');
    };

    return (
        <>
            <IconButton
                ref={anchorRef}
                onClick={handleOpen}
                sx={{
                    padding: 0,
                    width: 44,
                    height: 44,
                    ...(open && {
                        '&:before': {
                            zIndex: 1,
                            content: "''",
                            width: '100%',
                            height: '100%',
                            borderRadius: '50%',
                            position: 'absolute',
                            bgcolor: (theme) => alpha(theme.palette.grey[900], 0.72)
                        }
                    })
                }}
            >
                <Avatar src={account.photoURL} alt="photoURL"/>
            </IconButton>

            <MenuPopover
                open={open}
                onClose={handleClose}
                anchorEl={anchorRef.current}
                sx={{ width: 220 }}
            >
                <Box sx={{ my: 1.5, px: 2.5 }}>
                    <Typography variant="subtitle1" noWrap>
                        Administrator
                    </Typography>
                    <Typography variant="body2" sx={{ color: 'text.secondary' }} noWrap>
                        {localStorage.getItem('Email')}
                    </Typography>
                </Box>
                <Divider sx={{ my: 1 }} />

                {MENU_OPTIONS.map((option) => (
                    <MenuItem
                        key={option.label}
                        to={option.linkTo}
                        component={RouterLink}
                        onClick={handleClose}
                        sx={{ typography: 'body2', py: 1, px: 2.5 }}
                    >
                        <Box
                            component={Icon}
                            icon={option.icon}
                            sx={{
                                mr: 2,
                                width: 24,
                                height: 24
                            }}
                        />
                        {option.label}
                    </MenuItem>
                ))}

                <Box sx={{ p: 2, pt: 1.5 }}>
                    <Button onClick={() => Logout()} fullWidth color="inherit" variant="outlined">
                        Logout
                    </Button>
                </Box>
            </MenuPopover>
        </>
    );
}

import PropTypes from 'prop-types';
import { useEffect } from 'react';
import { Link as RouterLink, useLocation } from 'react-router-dom';
// material
import { styled } from '@mui/material/styles';
import { Box, Link, Button, Drawer, Typography, Stack } from '@mui/material';
// components
import { Icon } from '@iconify/react';
import heartOutline from '@iconify/icons-eva/heart-outline';
import messageSquareOutline from '@iconify/icons-eva/message-square-outline';

import Logo from '../../components/Logo';
import Scrollbar from '../../components/Scrollbar';
import NavSection from '../../components/NavSection';
import { MHidden } from '../../components/@material-extend';
//
import adminSidebarConfig from './AdminSidebarConfig';
// ----------------------------------------------------------------------

const DRAWER_WIDTH = 280;

const RootStyle = styled('div')(({ theme }) => ({
    [theme.breakpoints.up('lg')]: {
        flexShrink: 0,
        width: DRAWER_WIDTH,
        zIndex: 1059
    }
}));
const AccountStyle = styled('div')(({ theme }) => ({
    display: 'flex',
    alignItems: 'center',
    padding: theme.spacing(2, 2.5),
    borderRadius: theme.shape.borderRadiusSm,
    backgroundColor: theme.palette.grey[200]
}));
// ----------------------------------------------------------------------

AdminDashboardSidebar.propTypes = {
    isOpenSidebar: PropTypes.bool,
    onCloseSidebar: PropTypes.func
};

export default function AdminDashboardSidebar({ isOpenSidebar, onCloseSidebar }) {
    const { pathname } = useLocation();

    useEffect(() => {
        if (isOpenSidebar) {
            onCloseSidebar();
        }
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [pathname]);

    const renderContent = (
        <Scrollbar
            sx={{
                height: '100%',
                '& .simplebar-content': { height: '100%', display: 'flex', flexDirection: 'column' }
            }}
        >
            <Box sx={{ px: 2.5, py: 3 }}>
                <Box component={RouterLink} to="/" sx={{ display: 'inline-flex' }}>
                    <Logo />
                </Box>
            </Box>
            <Box sx={{ mb: 5, mx: 2.5 }}>
                <Link underline="none" component={RouterLink} to="/adminDashboard/support">
                    <AccountStyle>
                        <Icon icon={heartOutline} width={23} height={23} />
                        <Box sx={{ ml: 2 }}>
                            <Typography variant="subtitle2" sx={{ color: 'text.primary' }}>
                                Support
                            </Typography>
                        </Box>
                    </AccountStyle>
                </Link>
            </Box>
            <NavSection navConfig={adminSidebarConfig} />

            <Box sx={{ flexGrow: 1 }} />

            <Box sx={{ px: 2.5, pb: 3, mt: 10 }}>
                <Stack
                    alignItems="center"
                    spacing={3}
                    sx={{
                        p: 2.5,
                        pt: 5,
                        borderRadius: 2,
                        position: 'relative',
                        bgcolor: 'grey.200',
                        bottom: 65
                    }}
                >
                    <Button
                        fullWidth
                        href="https://emlakofisimden.com/"
                        target="_blank"
                        variant="contained"
                        sx={{
                            bottom: 10
                        }}
                    >
                        MediLaw Market
                    </Button>
                </Stack>
            </Box>
        </Scrollbar>
    );

    return (
        <RootStyle>
            <MHidden width="lgUp">
                <Drawer
                    open={isOpenSidebar}
                    onClose={onCloseSidebar}
                    PaperProps={{
                        sx: { width: DRAWER_WIDTH }
                    }}
                >
                    {renderContent}
                </Drawer>
            </MHidden>

            <MHidden width="lgDown">
                <Drawer
                    open
                    variant="persistent"
                    PaperProps={{
                        sx: {
                            width: DRAWER_WIDTH,
                            bgcolor: 'background.default'
                        }
                    }}
                >
                    {renderContent}
                </Drawer>
            </MHidden>
        </RootStyle >
    );
}

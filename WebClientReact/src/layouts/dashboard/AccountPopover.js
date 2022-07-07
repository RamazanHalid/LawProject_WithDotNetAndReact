import { Icon } from '@iconify/react';
import {useEffect, useRef, useState} from 'react';
import homeOutline from '@iconify/icons-eva/home-outline';
import personDoneOutline from '@iconify/icons-eva/person-done-outline';
import npmOutline from '@iconify/icons-eva/npm-outline';
import { Link as RouterLink, useNavigate } from 'react-router-dom';
import archiveOutline from '@iconify/icons-eva/archive-outline';

// material
import { alpha } from '@mui/material/styles';
import {Button, Box, Divider, MenuItem, Typography, IconButton, Avatar} from '@mui/material';
// components
 import MenuPopover from '../../components/MenuPopover';
//
import AuthService from '../../services/auth.service';
import ProfileService from "../../services/profile.service";
// ----------------------------------------------------------------------

const MENU_OPTIONS = [
  {
    label: 'Home',
    icon: homeOutline,
    linkTo: '/'
  },
  {
    label: 'Profile',
    icon: personDoneOutline,
    linkTo: '/dashboard/profile'
  },
  {
    label: 'Connected Licences',
    icon: archiveOutline,
    linkTo: '/dashboard/connectedLicences'
  },
  {
    label: 'Admin Panel',
    icon: npmOutline,
    linkTo: '/adminDashboard/admin'
  }
];

// ----------------------------------------------------------------------

export default function AccountPopover() {
  const anchorRef = useRef(null);
  const [open, setOpen] = useState(false);
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [email, setEmail] = useState('');
  const [profileImage, setProfileImage] = useState(0);

  const navigate = useNavigate();
  const authService = new AuthService()
  const profileService = new ProfileService();

  function userInfo() {
    profileService.getUserInfo().then(result => {
      if (result.data.Success) {
        let info = result.data.Data
        setFirstName(info.FirstName)
        setLastName(info.LastName)
        setEmail(info.Email)
        setProfileImage(info.ProfileImage)
      }
    })
  }

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
  useEffect(() => {
    userInfo();
  }, []);

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
        <Avatar src={'https://webapi.emlakofisimden.com/' + profileImage} alt="photoURL"/>
      </IconButton>

      <MenuPopover
        open={open}
        onClose={handleClose}
        anchorEl={anchorRef.current}
        sx={{ width: 220 }}
      >
        <Box sx={{ my: 1.5, px: 2.5 }}>
          <Typography variant="subtitle1" noWrap>
            {firstName} {lastName}
          </Typography>
          <Typography variant="body2" sx={{ color: 'text.secondary' }} noWrap>
            {email}
          </Typography>
        </Box>

        <Divider sx={{ my: 1}} />

          <MenuItem
            key='Home'
            to='/dashboard'
            component={RouterLink}
            onClick={handleClose}
            sx={{ typography: 'body2', py: 1, px: 2.5 }}
          >
            <Box
              component={Icon}
              icon={homeOutline}
              sx={{
                mr: 2,
                width: 24,
                height: 24
              }}
            />
            Home
          </MenuItem>
        <MenuItem
            key='Profile'
            to='/dashboard/profile'
            component={RouterLink}
            onClick={handleClose}
            sx={{ typography: 'body2', py: 1, px: 2.5 }}
        >
          <Box
              component={Icon}
              icon={personDoneOutline}
              sx={{
                mr: 2,
                width: 24,
                height: 24
              }}
          />
          Profile
        </MenuItem>
        <MenuItem
            key='Connected Licences'
            to='/dashboard/connectedLicences'
            component={RouterLink}
            onClick={handleClose}
            sx={{ typography: 'body2', py: 1, px: 2.5 }}
        >
          <Box
              component={Icon}
              icon={archiveOutline}
              sx={{
                mr: 2,
                width: 24,
                height: 24
              }}
          />
          Connected Licences
        </MenuItem>
        {authService.DoesHaveMandatoryClaim('admin')?
        <MenuItem
            key='Admin Panel'
            to='/adminDashboard/admin'
            component={RouterLink}
            onClick={handleClose}
            sx={{ typography: 'body2', py: 1, px: 2.5 }}
        >
          <Box
              component={Icon}
              icon={npmOutline}
              sx={{
                mr: 2,
                width: 24,
                height: 24
              }}
          />
          Admin Panel
        </MenuItem>
            : null}

        <Box sx={{ p: 2, pt: 1.5 }}>
          <Button onClick={() => Logout()} fullWidth color="inherit" variant="outlined">
            Logout
          </Button>
        </Box>
      </MenuPopover>
    </>
  );
}

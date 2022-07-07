import { Link as RouterLink } from 'react-router-dom';
import { Icon } from '@iconify/react';
import sharpWifiProtectedSetup from '@iconify/icons-ic/sharp-wifi-protected-setup';
// material
import { alpha, styled } from '@mui/material/styles';
import { Card, Typography, Link } from '@mui/material';
// ----------------------------------------------------------------------

const RootStyle = styled(Card)(({ theme }) => ({
  boxShadow: 'none',
  textAlign: 'center',
  padding: theme.spacing(5, 0),
  color: theme.palette.purple.darker,
  backgroundColor: theme.palette.purple.lighter
}));

const IconWrapperStyle = styled('div')(({ theme }) => ({
  margin: 'auto',
  display: 'flex',
  borderRadius: '50%',
  alignItems: 'center',
  width: theme.spacing(8),
  height: theme.spacing(8),
  justifyContent: 'center',
  marginBottom: theme.spacing(3),
  color: theme.palette.purple.dark,
  backgroundImage: `linear-gradient(135deg, ${alpha(theme.palette.purple.dark, 0)} 0%, ${alpha(
    theme.palette.purple.dark,
    0.24
  )} 100%)`
}));

// ----------------------------------------------------------------------

export default function ProcessBox() {
  return (
    <RootStyle>
      <Link
        to="/dashboard/definitions/processType"
        component={RouterLink}
        style={{ textDecoration: 'none', color: '#68547a' }}
      >
        <IconWrapperStyle>
          <Icon icon={sharpWifiProtectedSetup} width={24} height={24} />
        </IconWrapperStyle>
      <Typography variant="h3">
          Process Type
      </Typography>
        <Typography variant="subtitle1" sx={{ opacity: 0.72 }}>
          Process & Document Type
        </Typography>
      </Link>
    </RootStyle>
  );
}

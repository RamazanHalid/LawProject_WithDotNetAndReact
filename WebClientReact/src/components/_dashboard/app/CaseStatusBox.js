import { Link as RouterLink } from 'react-router-dom';
import { Icon } from '@iconify/react';
import roundCases from '@iconify/icons-ic/round-cases';
// material
import { alpha, styled } from '@mui/material/styles';
import { Card, Typography, Link } from '@mui/material';
// utils
// ----------------------------------------------------------------------

const RootStyle = styled(Card)(({ theme }) => ({
  boxShadow: 'none',
  textAlign: 'center',
  padding: theme.spacing(5, 0),
  color: theme.palette.green.darker,
  backgroundColor: theme.palette.green.lighter,
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
  color: theme.palette.green.dark,
  backgroundImage: `linear-gradient(135deg, ${alpha(theme.palette.green.dark, 0)} 0%, ${alpha(
    theme.palette.green.dark,
    0.24
  )} 100%)`
}));

// ----------------------------------------------------------------------

export default function CaseStatusBox() {
  return (

      <Link
        to="/dashboard/definitions/caseStatus"
        component={RouterLink}
        style={{ textDecoration: 'none', color: '#372' }}
      >
        <RootStyle>
        <IconWrapperStyle>
          <Icon icon={roundCases} width={24} height={24} />
        </IconWrapperStyle>
      <Typography variant="h3">
          Case Status
      </Typography>
        <Typography variant="subtitle2" sx={{ opacity: 0.72 }}>
          Case Status
        </Typography>
        </RootStyle>
      </Link>

  );
}

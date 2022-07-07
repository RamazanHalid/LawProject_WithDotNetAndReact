import { Link as RouterLink } from 'react-router-dom';
import { Icon } from '@iconify/react';
import baselineTask from '@iconify/icons-ic/baseline-task';
// material
import { alpha, styled } from '@mui/material/styles';
import { Card, Typography, Link } from '@mui/material';
// utils

// ----------------------------------------------------------------------

const RootStyle = styled(Card)(({ theme }) => ({
  boxShadow: 'none',
  textAlign: 'center',
  padding: theme.spacing(5, 0),
  color: '#f2cdf7',
  backgroundColor: '#fef2ff'
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
  color: '#8c4d94',
  backgroundImage: `linear-gradient(135deg, ${alpha(theme.palette.primary.dark, 0)} 0%, ${alpha(
    theme.palette.primary.dark,
    0.24
  )} 100%)`
}));

// ----------------------------------------------------------------------

export default function TaskTypeBox() {
  return (
    <RootStyle>
      <Link
        to="/dashboard/definitions/taskType"
        component={RouterLink}
        style={{ textDecoration: 'none', color: '#8c4d94' }}
      >
        <IconWrapperStyle>
          <Icon icon={baselineTask} width={24} height={24} />
        </IconWrapperStyle>
      <Typography variant="h3">
          Task Type
      </Typography>
        <Typography variant="subtitle2" sx={{ opacity: 0.72 }}>
          Task Type
        </Typography>
      </Link>
    </RootStyle>
  );
}

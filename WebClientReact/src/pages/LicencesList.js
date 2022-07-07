// material
import { styled } from '@mui/material/styles';
import { Container, Typography } from '@mui/material';
// components
import Page from '../components/Page';
import { LicencesListForm } from '../components/authentication/LicencesListForm';

// ----------------------------------------------------------------------

const RootStyle = styled(Page)(({ theme }) => ({
  [theme.breakpoints.up('md')]: {
    display: 'flex'
  }
}));

// ----------------------------------------------------------------------

export default function LicencesList() {
  return (
    <RootStyle title="Licences | MediLaw">
      <Container>
        <Typography variant="h4" gutterBottom />
        <LicencesListForm />
      </Container>
    </RootStyle>
  );
}

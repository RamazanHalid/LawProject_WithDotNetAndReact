 // material
import { styled } from '@mui/material/styles';
import { Container, Typography } from '@mui/material';
// components
import Page from '../components/Page';
import LicenceSettings from "./LicenceSettings";
// ----------------------------------------------------------------------

const RootStyle = styled(Page)(({ theme }) => ({
  [theme.breakpoints.up('md')]: {
    display: 'flex'
  }
}));

// ----------------------------------------------------------------------

export default function Licences() {
  return (
    <RootStyle title="Licences | MediLaw">
      <Container>
        <Typography variant="h4" mb={14} pt={2} gutterBottom />
        <LicenceSettings />
      </Container>
    </RootStyle>
  );
}

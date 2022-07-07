 // material
import { Box, Grid, Container, Typography } from '@mui/material';
import CaseStatusBox from '../components/_dashboard/app/CaseStatusBox';
import CaseTypeBox from '../components/_dashboard/app/CaseTypeBox';
import TaskTypeBox from '../components/_dashboard/app/TaskTypeBox.js';
import AccountActivityBox from '../components/_dashboard/app/AccountActivityBox';
import CourtBox from '../components/_dashboard/app/CourtBox';
import ProcessBox from '../components/_dashboard/app/ProcessBox';
// components
import Page from '../components/Page';
import AuthService from '../services/auth.service';
// ----------------------------------------------------------------------

export default function DashboardApp() {
  const authService = new AuthService()
  return (
    <Page title="Definitions | MediLaw">
      <Container maxWidth="xl">
        <Box sx={{ pb: 5 }}>
          <Typography variant="h4">Definitions</Typography>
        </Box>
        <Grid container spacing={3}>
          {authService.DoesHaveMandatoryClaim('CaseStatusGetAll') ||
          authService.DoesHaveMandatoryClaim('CaseStatusGetAllActive') ||
          authService.DoesHaveMandatoryClaim('LicenceOwner') ? (
            <Grid item xs={12} sm={6} md={3}>
              <CaseStatusBox />
            </Grid>
          ) : null}
          {authService.DoesHaveMandatoryClaim('CaseTypeGetAll') ||
          authService.DoesHaveMandatoryClaim('CaseTypeCaseTypeGet') ||
          authService.DoesHaveMandatoryClaim('LicenceOwner') ? (
            <Grid item xs={12} sm={6} md={3}>
              <CaseTypeBox />
            </Grid>
          ) : null}
          {authService.DoesHaveMandatoryClaim('CourtOfficeGetAll')  ||
          authService.DoesHaveMandatoryClaim('LicenceOwner')? (
            <Grid item xs={12} sm={6} md={3}>
              <CourtBox />
            </Grid>
          ) : null}
          {authService.DoesHaveMandatoryClaim('TransactionActivitySubTypeGetAll') ||
          authService.DoesHaveMandatoryClaim('TransactionActivitySubTypeGet')  ||
          authService.DoesHaveMandatoryClaim('LicenceOwner')? (
            <Grid item xs={12} sm={6} md={3}>
              <AccountActivityBox />
            </Grid>
          ) : null}
          {authService.DoesHaveMandatoryClaim('TaskTypeGetAll') ||
          authService.DoesHaveMandatoryClaim('TaskTypeGet') ||
          authService.DoesHaveMandatoryClaim('LicenceOwner') ? (
            <Grid item xs={12} sm={6} md={3}>
              <TaskTypeBox />
            </Grid>
          ) : null}
          {authService.DoesHaveMandatoryClaim('ProcessTypeGetAll') ||
          authService.DoesHaveMandatoryClaim('ProcessTypeGet')  ||
          authService.DoesHaveMandatoryClaim('LicenceOwner')? (
            <Grid item xs={12} sm={6} md={3}>
              <ProcessBox />
            </Grid>
          ) : null}
        </Grid>
      </Container>
    </Page>
  );
}

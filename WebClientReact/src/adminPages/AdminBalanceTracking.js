// material
import { Box, Grid, Container, Typography } from '@mui/material';
import Page from '../components/Page';

export default function AdminBalanceTracking() {

    return (
        <Page title="Balance Tracking | MediLaw">
            <Container maxWidth="xl">
                <Box sx={{ pb: 10 }}>
                    <Typography variant="h4">Balance Tracking</Typography>
                    <Grid container spacing={3}>
                    </Grid>
                </Box>
            </Container>
        </Page>
    );
}

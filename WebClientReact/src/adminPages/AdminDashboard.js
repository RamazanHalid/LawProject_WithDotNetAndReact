// material
import {Box, Grid, Container, Typography, Stack} from '@mui/material';
import Stepper from '@mui/material/Stepper';
import Step from '@mui/material/Step';
import StepLabel from '@mui/material/StepLabel';
// components
import {useNavigate} from 'react-router-dom';
import React, {useEffect} from 'react';
import AuthService from '../services/auth.service';
import Page from '../components/Page';
import AppConversionRates from "../components/_dashboard/user/AppConversionRates";
import AppNewsUpdate from "../components/_dashboard/user/AppNewsUpdate";
import AppTrafficBySite from "../components/_dashboard/user/AppTraficBySite";
import ConnectedClients from "../components/_dashboard/app/ConnectedClients";
import ConnectedTasks from "../components/_dashboard/app/ConnectedTasks";
import ConnectedEvents from "../components/_dashboard/app/ConnectedEvents";
import ConnectedCases from "../components/_dashboard/app/ConnectedCases";
import TotalLicences from "../components/_dashboard/adminApp/TotalLicences";
import TotalUsers from "../components/_dashboard/adminApp/TotalUsers";
import TotalSentMessages from "../components/_dashboard/adminApp/TotalSentMessages";
import TotalBalance from "../components/_dashboard/adminApp/TotalBalance";

export default function AdminDashboard() {
    const navigate = useNavigate();
    const authService = new AuthService();
    const steps = [
        'Select master blaster campaign settings',
        'Create an ad group',
        'Create an ad',
    ];

    useEffect(() => {
        if (!authService.IsAuth()) {
            navigate('/login');
        }
    }, []);

    return (
        <Page title="Admin Dashboard | MediLaw">
            <Container maxWidth="xl">
                <Box sx={{pb: 5}}>
                    <Typography variant="h4">MediLaw Admin</Typography>
                </Box>
                <Grid container spacing={1} marginLeft={3}>
                    <Grid item xs={12} md={5} lg={3.8} mt={2}>
                    <TotalLicences/>
                    </Grid>
                    <Grid item xs={12} md={5} lg={3.8} mt={2}>
                    <TotalUsers/>
                    </Grid>
                    <Grid item xs={12} md={5} lg={3.8} mt={2}>
                    <TotalBalance/>
                    </Grid>
                    <Grid item xs={12} md={5} lg={3.8} mt={2}>
                    <TotalSentMessages/>
                    </Grid>
                </Grid>
            </Container>
        </Page>
    );
}

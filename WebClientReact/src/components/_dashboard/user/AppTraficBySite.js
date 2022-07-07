// @mui
import PropTypes from 'prop-types';
import { Box, Card, Paper, Typography, CardHeader, CardContent } from '@mui/material';
// utils
import ConnectedClients from "../app/ConnectedClients";
import ConnectedCases from "../app/ConnectedCases";
import ConnectedEvents from "../app/ConnectedEvents";
import ConnectedTasks from "../app/ConnectedTasks";
import React from "react";

// ----------------------------------------------------------------------

AppTrafficBySite.propTypes = {
    title: PropTypes.string,
    subheader: PropTypes.string,
    list: PropTypes.array.isRequired,
};

export default function AppTrafficBySite({ title, subheader, list, ...other }) {
    return (
        <Card {...other}>
            <CardHeader title="Total Counts"/>
            <CardContent>
                <Box
                    sx={{
                        display: 'grid',
                        gap: 3,
                        gridTemplateColumns: 'repeat(2, 1fr)',
                    }}
                >
                    <ConnectedClients/>
                    <ConnectedTasks/>
                    <ConnectedEvents/>
                    <ConnectedCases/>
                </Box>
            </CardContent>
        </Card>
    );
}
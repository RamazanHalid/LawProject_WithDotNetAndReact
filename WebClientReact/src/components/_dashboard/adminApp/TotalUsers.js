// material
import {styled} from '@mui/material/styles';
import {Card, Typography, Stack} from '@mui/material';
import React from "react";
import baselinePerson from '@iconify/icons-ic/baseline-person';
import {Icon} from "@iconify/react";
// ----------------------------------------------------------------------

const RootStyle = styled(Card)(({theme}) => ({
    boxShadow: 9,
    textAlign: 'left',
    paddingLeft: 30,
    paddingTop: 20,
    color: '#629674',
    backgroundColor: '#e3f6e7',
    width: 325,
    height: 154
}));

const IconWrapperStyle = styled('div')(({ theme }) => ({
    margin: 'auto',
    display: 'flex',
    borderRadius: '50%',
    marginRight: -28,
    paddingTop: 0,
    alignItems: 'center',
    width: theme.spacing(20),
    height: theme.spacing(20),
    justifyContent: 'center',
    color: '#629674'
}));

// ----------------------------------------------------------------------

export default function TotalLicences() {
    return (

        <RootStyle>
            <Stack flexDirection='row'>
                <Stack flexDirection='column'>
                    <Typography variant="subtitle1" paddingLeft={0} paddingTop={1}>
                        Total Active Users
                    </Typography>
                    <Typography variant="h3" sx={{paddingTop: 3}}>
                        677
                    </Typography>
                </Stack>
                <IconWrapperStyle>
                    <Icon icon={baselinePerson} width={350} height={350}/>
                </IconWrapperStyle>
            </Stack>
        </RootStyle>
    );
}

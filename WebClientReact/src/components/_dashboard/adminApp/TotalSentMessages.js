// material
import {styled} from '@mui/material/styles';
import {Card, Typography, Stack} from '@mui/material';
import React from "react";
import baselineWechat from '@iconify/icons-ic/baseline-wechat';
import {Icon} from "@iconify/react";
// ----------------------------------------------------------------------

const RootStyle = styled(Card)(({theme}) => ({
    boxShadow: 9,
    textAlign: 'left',
    paddingLeft: 30,
    paddingTop: 20,
    color: '#626796',
    backgroundColor: '#e3e3f5',
    width: 325,
    height: 154
}));

const IconWrapperStyle = styled('div')(({ theme }) => ({
    margin: 'auto',
    display: 'flex',
    borderRadius: '50%',
    marginRight: -35,
    paddingTop: 0,
    alignItems: 'center',
    width: theme.spacing(22),
    height: theme.spacing(23),
    justifyContent: 'center',
    color: '#626796'
}));

// ----------------------------------------------------------------------

export default function TotalLicences() {
    return (

        <RootStyle>
            <Stack flexDirection='row'>
                <Stack flexDirection='column'>
                    <Typography variant="subtitle1" paddingLeft={0} paddingTop={1}>
                        Total Sent Messages
                    </Typography>
                    <Typography variant="h3" sx={{paddingTop: 3}}>
                        677
                    </Typography>
                </Stack>
                <IconWrapperStyle>
                    <Icon icon={baselineWechat} width={350} height={350}/>
                </IconWrapperStyle>
            </Stack>
        </RootStyle>
    );
}

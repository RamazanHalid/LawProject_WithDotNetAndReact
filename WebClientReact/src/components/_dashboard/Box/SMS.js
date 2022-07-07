import { Link as RouterLink } from 'react-router-dom';
import { MessageSquare } from 'react-feather';
// material
import { alpha, styled } from '@mui/material/styles';
import {Card, Typography, Link, Stack} from '@mui/material';
import LicencesService from "../../../services/licences.service";
import {Global} from "../../../Global";
import PopupMessageService from "../../../services/popupMessage.service";
import {useEffect, useState} from "react";
// ----------------------------------------------------------------------

const RootStyle = styled(Card)(({ theme }) => ({
    textAlign: 'flex-start',
    boxShadow: 24,
    padding:20,
    width: 260,
    height:150,
    color: '#305724',
    backgroundColor: '#e5fcde'
}));

const IconWrapperStyle = styled('div')(({ theme }) => ({
    margin: 'auto',
    display: 'flex',
    borderRadius: '50%',
    marginRight: '8%',
    alignItems: 'center',
    width: theme.spacing(8),
    height: theme.spacing(8),
    justifyContent: 'center',
    color: '#305724',
    backgroundImage: `linear-gradient(135deg, ${alpha(theme.palette.info.dark, 0)} 0%, ${alpha(
        '#305724',
        0.24
    )} 100%)`,
}));

// ----------------------------------------------------------------------

export default function SMS() {
    const licencesService = new LicencesService();
    const catchMessagee = Global.catchMessage;
    const popupMessageService = new PopupMessageService();
    const [smsForLicenceData, setSmsForLicenceData] = useState(0);

    const getLicenceInfo = () => {
        licencesService.getLicenceInfoCounts().then(
            (result) => {
                if (result.data.Success) {
                    setSmsForLicenceData(result.data.Data.Sms)
                }
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    };

    useEffect(() => {
        getLicenceInfo();
    }, [])


    return (
        <RootStyle>
            <Link
                to="/dashboard/Messages"
                component={RouterLink}
                style={{ textDecoration: 'none', color: '#305724' }}
            >
                <Typography variant="subtitle4" sx={{ opacity: 0.72 }}>
                    SMS
                </Typography>
                <Stack flexDirection='row' mt={2}>
                    <Typography variant="h3" paddingLeft={2} paddingTop={1}>
                        {smsForLicenceData}
                    </Typography>
                    <IconWrapperStyle>
                        <MessageSquare width={24} height={24} />
                    </IconWrapperStyle>
                </Stack>
            </Link>
        </RootStyle>
    );
}

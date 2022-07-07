import { Link as RouterLink } from 'react-router-dom';
import { BarChart2 } from 'react-feather';
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
    color: '#753469',
    backgroundColor: '#ffd9f8'
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
    color: '#753469',
    backgroundImage: `linear-gradient(135deg, ${alpha(theme.palette.info.dark, 0)} 0%, ${alpha(
        '#753469',
        0.24
    )} 100%)`
}));

// ----------------------------------------------------------------------

export default function TransactionActivitySize() {
    const licencesService = new LicencesService();
    const catchMessagee = Global.catchMessage;
    const popupMessageService = new PopupMessageService();
    const [transactionActivityForLicenceData, setTransactionActivityForLicenceData] = useState(0);


    const getLicenceInfo = () => {
        licencesService.getLicenceInfoCounts().then(
            (result) => {
                if (result.data.Success) {
                    setTransactionActivityForLicenceData(result.data.Data.TransactionActivity)
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
                to="/dashboard/accountActivities"
                component={RouterLink}
                style={{ textDecoration: 'none', color: '#753469' }}
            >
                <Typography variant="subtitle4" sx={{ opacity: 0.72 }}>
                    Transaction Activity
                </Typography>
                <Stack flexDirection='row' mt={2}>
                    <Typography variant="h3" paddingLeft={2} paddingTop={1}>
                        {transactionActivityForLicenceData}
                    </Typography>
                    <IconWrapperStyle>
                        <BarChart2 width={24} height={24} />
                    </IconWrapperStyle>
                </Stack>
            </Link>
        </RootStyle>
    );
}

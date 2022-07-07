// material
import { alpha, styled } from '@mui/material/styles';
import {Card, Typography, Stack} from '@mui/material';
import LicencesService from "../../../services/licences.service";
import {Global} from "../../../Global";
import PopupMessageService from "../../../services/popupMessage.service";
import {useEffect, useState} from "react";
import {Icon} from "@iconify/react";
import creditCardOutline from '@iconify/icons-eva/credit-card-outline';
// ----------------------------------------------------------------------

const RootStyle = styled(Card)(({ theme }) => ({
    textAlign: 'flex-start',
    boxShadow: 24,
    padding:20,
    width: 260,
    height:150,
    color: '#59388a',
    backgroundColor: '#decdf7'
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
    color: '#59388a',
    backgroundImage: `linear-gradient(135deg, ${alpha(theme.palette.info.dark, 0)} 0%, ${alpha(
        '#59388a',
        0.24
    )} 100%)`
}));

// ----------------------------------------------------------------------

export default function CurrentBalance() {
    const licencesService = new LicencesService();
    const catchMessagee = Global.catchMessage;
    const popupMessageService = new PopupMessageService();
    const [currentBalanceForLicenceData, setCurrentBalanceForLicenceData] = useState(0);

    const getLicenceInfo = () => {
        licencesService.getLicenceInfoCounts().then(
            (result) => {
                if (result.data.Success) {
                    setCurrentBalanceForLicenceData(result.data.Data.CurrentBalance)
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
                <Typography variant="subtitle4" sx={{ opacity: 0.72 }}>
                    Current Balance
                </Typography>
                <Stack flexDirection='row' mt={2}>
                    <Typography variant="h3" paddingLeft={2} paddingTop={1}>
                        {currentBalanceForLicenceData} ₺
                    </Typography>
                    <IconWrapperStyle>
                        <Icon icon={creditCardOutline} width={30} height={30} />
                    </IconWrapperStyle>
                </Stack>
        </RootStyle>
    );
}

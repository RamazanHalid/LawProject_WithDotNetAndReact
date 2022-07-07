import { HardDrive } from 'react-feather';
// material
import { alpha, styled } from '@mui/material/styles';
import {Card, Typography, Stack} from '@mui/material';
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
    color: '#27446e',
    backgroundColor: '#bed7fa'
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
    color: '#27446e',
    backgroundImage: `linear-gradient(135deg, ${alpha(theme.palette.info.dark, 0)} 0%, ${alpha(
        '#27446e',
        0.24
    )} 100%)`
}));

// ----------------------------------------------------------------------

export default function CurrentlyUsed() {
    const licencesService = new LicencesService();
    const catchMessagee = Global.catchMessage;
    const popupMessageService = new PopupMessageService();
    const [currentlyUsedDiskSpaceForLicenceData, setCurrentlyUsedDiskSpaceForLicenceData] = useState(0);
    const [totalDiskSpaceForLicenceData, setTotalDiskSpaceForLicenceData] = useState(0);

    const getLicenceInfo = () => {
        licencesService.getLicenceInfoCounts().then(
            (result) => {
                if (result.data.Success) {
                    setCurrentlyUsedDiskSpaceForLicenceData(result.data.Data.CurrentlyUsedDiskSpace)
                    setTotalDiskSpaceForLicenceData(result.data.Data.TotalDiskSpace)
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
                    Currently Used Disk Space
                </Typography>
                <Stack flexDirection='row' mt={2}>
                    <Typography variant="h3" paddingLeft={2} paddingTop={1}>
                        {currentlyUsedDiskSpaceForLicenceData}/{totalDiskSpaceForLicenceData} GB
                    </Typography>
                    <IconWrapperStyle>
                        <HardDrive width={24} height={24} />
                    </IconWrapperStyle>
                </Stack>
        </RootStyle>
    );
}

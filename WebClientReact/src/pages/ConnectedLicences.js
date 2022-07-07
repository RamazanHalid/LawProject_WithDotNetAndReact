import React, {useEffect, useState} from 'react';

// material
import {
    Stack,
    Button,
    Typography,
    TableContainer,
    Table,
    TableHead,
    TableRow,
    TableCell,
    TableBody,
    Paper, Card, Container
} from '@mui/material';
import {Icon} from "@iconify/react";
import Scrollbar from "../components/Scrollbar";
import CircularProgress from "@mui/material/CircularProgress";
import checkmarkCircleOutline from "@iconify/icons-eva/checkmark-circle-outline";
import closeCircleOutline from '@iconify/icons-eva/close-circle-outline';
import LicenceUsersService from "../services/licenceUsers.service";
import PopupMessageService from "../services/popupMessage.service";
import Page from "../components/Page";
import palette from "../theme/palette";
import AuthService from "../services/auth.service";

// ----------------------------------------------------------------------

export default function ConnectedLicences() {
    const [isLoading, setIsLoading] = useState(true);
    const [licenceUsers, setLicenceUsers] = useState([]);

    const licenceUserService = new LicenceUsersService();
    const popupMessageService = new PopupMessageService();
    const authService = new AuthService();

    const getAllLicenceUser = () => {
        if (true) {
            licenceUserService.GetAllByUserIdWithNotAccept().then(
                (result) => {
                    if (result.data.Success) {
                        setLicenceUsers(result.data.Data);
                        setIsLoading(false)
                    }
                },
                (error) => {
                    popupMessageService.AlertErrorMessage(error.response.data.Message);
                }
            );
        }
    };

    function AcceptRequest(id) {
        licenceUserService.ChangeAcceptence(id).then(result => {
            getAllLicenceUser()
            popupMessageService.AlertSuccessMessage(result.data.Message);
        })
    }

    useEffect(() => {
        getAllLicenceUser();
    }, [])
    return (
        <Page title="Transaction Activities | MediLaw">
                <Container>
                    <Stack direction="row" alignItems="center" justifyContent="space-between" mb={4}>
                        <Typography variant="h4" gutterBottom>
                    Connected Licences!
                </Typography>
                    </Stack>
                    {authService.DoesHaveMandatoryClaim('LicenceOwner') ? (
                <Stack spacing={2}>
                    <Card sx={{marginTop: 6, maxWidth:900, marginLeft: 10}}>
                        <Scrollbar>
                            {isLoading === true ?
                                <Stack sx={{color: 'grey.500'}} spacing={2} direction="row" justifyContent='center'>
                                    <CircularProgress color="inherit"/>
                                </Stack>
                                :
                                <>
                                    {licenceUsers.length > 0 ? (
                                        <TableContainer component={Paper}>
                                            <Table sx={{minWidth: 650}} aria-label="simple table">
                                                <TableHead>
                                                    <TableRow sx={{backgroundColor: '#f7f7f7'}}>
                                                        <TableCell sx={{paddingLeft: 7}}>Profile Name</TableCell>
                                                        <TableCell align="left">Website</TableCell>
                                                        <TableCell align="left">Phone Number</TableCell>
                                                        <TableCell align="right"/>
                                                        <TableCell align="right"/>
                                                    </TableRow>
                                                </TableHead>
                                                <TableBody>
                                                    <>
                                                        {
                                                            licenceUsers
                                                                .map((row) => (
                                                                    <TableRow
                                                                        key={row.LicenceUserId}
                                                                        sx={{'&:last-child td, &:last-child th': {border: 0}}}
                                                                    >
                                                                        <TableCell component="th" scope="row"
                                                                                   sx={{paddingLeft: 7}}>
                                                                            {row.LicenceGetDto.ProfilName}
                                                                        </TableCell>
                                                                        <TableCell component="th" scope="row">
                                                                            {row.LicenceGetDto.WebSite}
                                                                        </TableCell>
                                                                        <TableCell component="th" scope="row">
                                                                            {row.LicenceGetDto.PhoneNumber}
                                                                        </TableCell>
                                                                        <TableCell align="left">
                                                                            {row.IsUserAccept === false ?
                                                                            <Button
                                                                                variant="contained"
                                                                                onClick={() => AcceptRequest(row.LicenceUserId)}
                                                                                sx={{backgroundColor: palette.green.dark}}
                                                                                startIcon={<Icon
                                                                                    icon={checkmarkCircleOutline}/>}
                                                                            >
                                                                                Accept
                                                                            </Button>
                                                                                :
                                                                                <Button
                                                                                    variant="contained"
                                                                                    sx={{backgroundColor: '#c9505c'}}
                                                                                    startIcon={<Icon
                                                                                        icon={closeCircleOutline}/>}
                                                                                >
                                                                                    Check out
                                                                                </Button>
                                                                            }
                                                                        </TableCell>
                                                                    </TableRow>
                                                                ))}
                                                    </>
                                                </TableBody>
                                            </Table>
                                        </TableContainer>
                                    ) : (
                                        <TableCell sx={{width: '40%'}}>
                                            <img src="/static/illustrations/no.png" alt="login"/>
                                            <Typography variant="h3" gutterBottom textAlign='center' color='#a9a9a9'>No
                                                Data Found!</Typography>
                                        </TableCell>
                                    )}
                                </>
                            }
                        </Scrollbar>
                    </Card>
                </Stack>
                        ): <Typography>Sorry, you don't have the authorization to perform this action!</Typography>}
            </Container>
        </Page>
    );
}

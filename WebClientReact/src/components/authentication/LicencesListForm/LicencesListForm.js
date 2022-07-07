import React, {useEffect, useState} from 'react';
import {useNavigate, useParams} from 'react-router-dom';

// material
import {
    Stack,
    Typography, Card, Avatar
} from '@mui/material';
import {LoadingButton} from '@mui/lab';
import PopupMessageService from '../../../services/popupMessage.service';
import {Global} from '../../../Global';
import LicencesService from '../../../services/licences.service';
import LicenceUsersService from '../../../services/licenceUsers.service';
import AuthService from '../../../services/auth.service';
import arrowForwardOutline from '@iconify/icons-eva/arrow-forward-outline';
import {Icon} from "@iconify/react";
import CircularProgress from "@mui/material/CircularProgress";
import account from "../../../_mocks_/account";
// ----------------------------------------------------------------------

export default function LicencesListForm() {
    const [licence, setLicence] = useState([]);
    const [licenceUsers, setLicenceUsers] = useState([]);
    const [usr, setUsr] = useState();
    const [isLoading, setIsLoading] = useState(true);

    const popupMessageService = new PopupMessageService();
    const licencesService = new LicencesService();
    const licenceUsersService = new LicenceUsersService();
    const authService = new AuthService();
    const catchMessagee = Global.catchMessage;

    const {id} = useParams();
    const navigate = useNavigate();

    const LoginWithLicence = (licenceId, licenceProfileName, email) => {
        authService.loginWithLicenceId(usr.cellPhone, usr.password, licenceId).then(
            (result) => {
                if (result.data.Success) {
                    localStorage.setItem('token', JSON.stringify(result.data.Data.AccessToken.Token));
                    localStorage.setItem('userClaims', JSON.stringify(result.data.Data.OperationClaims));
                    localStorage.setItem('LicenceName', licenceProfileName);
                    localStorage.setItem('Email', email);
                    navigate('/dashboard');
                }
            },
            (error) => {
                console.log(error.response.data.Message)
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    };

    const getAllLicences = () => {
        setUsr(JSON.parse(localStorage.getItem('usr')));
        licencesService
            .GetAllByUserId(id)
            .then(
                (response) => {
                    setLicence(response.data.Data);
                    setIsLoading(false)
                },
                (error) => {
                    popupMessageService.AlertErrorMessage(error.response.data.Message);
                }
            )
            .catch(() => {
                popupMessageService.AlertErrorMessage(catchMessagee)
            });
    }

    const getAllLicencesByUserId = () => {
        licenceUsersService
            .GetAllByUserId(id)
            .then(
                (response) => {
                    setLicenceUsers(response.data.Data);
                },
                (error) => {
                    popupMessageService.AlertErrorMessage(error.response.data.Message);
                }
            )
            .catch(() => {
                popupMessageService.AlertErrorMessage(catchMessagee)
            });
    }

    useEffect(() => {
        getAllLicences();
        getAllLicencesByUserId();
    }, []);

    return (
        <Stack spacing={2.5}>
            <Stack flexDirection='row' justifyContent='space-between' mt={6}>
                <Typography id="transition-modal-title" variant="h5" pb={4} pt={2}/>
            </Stack>
            <Stack flexDirection='row' justifyContent='center' paddingTop={5}>
                <Card container sx={{maxWidth: 450, minWidth: 450, minHeight: 280, padding: 4}}>
                    <>
                        {isLoading === true ?
                            <Stack sx={{color: 'grey.500', padding: 10}} spacing={2} direction="row"
                                   justifyContent='center' alignSelf='center' left='50%'>
                                <CircularProgress color="inherit"/>
                            </Stack>
                            :
                            <>
                                {licence.length > 0 ? (
                                    <>
                                        <Typography gutterBottom variant="h5" component="div" sx={{ borderBottom: '1px dashed #b1b9be', paddingBottom:3 }}>
                                            Please Choose a Licence!
                                        </Typography>
                                        {licence.map((row) => (
                                            <>
                                                <Stack sx={{flexDirection: 'row', marginTop: 4}}>
                                                    <Avatar src={account.photoURL} alt="photoURL"/>
                                                    <Stack sx={{flexDirection: 'column', paddingLeft: 3}}>
                                                        <Typography gutterBottom component="div" fontSize={16}
                                                                    fontWeight='bold' key={row.LicenceId}>
                                                            {row.ProfilName}
                                                        </Typography>
                                                        <Stack paddingTop={-3}>
                                                            <Typography
                                                                fontSize={12}>{row.PersonType.PersonTypeName} - {row.City.CityName}</Typography>
                                                        </Stack>
                                                    </Stack>
                                                    <LoadingButton
                                                        onClick={() => LoginWithLicence(row.LicenceId, row.ProfilName, row.Email)}
                                                        sx={{height: 30, marginLeft: 12, marginTop: 1}}
                                                        type="button"
                                                        size="medium"
                                                        variant="contained"
                                                        loading={false}
                                                        startIcon={<Icon icon={arrowForwardOutline}/>}
                                                    >
                                                        Continue
                                                    </LoadingButton>
                                                </Stack>
                                            </>
                                        ))}
                                    </>
                                ) : (
                                    <card sx={{width: '40%'}}>
                                        <img src="/static/illustrations/no.png" alt="login"/>
                                        <Typography variant="h4" gutterBottom textAlign='center' color='#a9a9a9'>No Data
                                            Found</Typography>
                                    </card>
                                )}
                            </>
                        }
                    </>
                </Card>
                <Card container sx={{maxWidth: 450, minWidth: 450, minHeight: 280, padding: 4, marginLeft: 10}}>
                    <>
                        {isLoading === true ?
                            <Stack sx={{color: 'grey.500', padding: 10}} spacing={2} direction="row"
                                   justifyContent='center' alignSelf='center' left='50%'>
                                <CircularProgress color="inherit"/>
                            </Stack>
                            :
                            <>
                                {licenceUsers.length > 0 ? (
                                    <>
                                        <Typography id="transition-modal-title" variant="h5" sx={{ borderBottom: '1px dashed #b1b9be', paddingBottom:3 }}>
                                            Your Registered Licences!
                                        </Typography>
                                        {licenceUsers.map((row) => (


                                            <Stack sx={{flexDirection: 'row', marginTop: 4}}>
                                                <Avatar src={account.photoURL2} alt="photoURL"/>
                                                <Stack sx={{flexDirection: 'column', paddingLeft: 3}}>
                                                    <Typography gutterBottom component="div" fontSize={16}
                                                                fontWeight='bold' key={row.LicenceUserId}>
                                                        {row.LicenceGetDto.ProfilName}
                                                    </Typography>
                                                </Stack>
                                                <LoadingButton
                                                    onClick={() => LoginWithLicence(row.LicenceGetDto.LicenceId, row.LicenceGetDto.ProfilName, row.LicenceGetDto.Email)}
                                                    sx={{height: 30, marginLeft: 12, marginTop: 1}}
                                                    type="button"
                                                    size="medium"
                                                    variant="contained"
                                                    loading={false}
                                                    startIcon={<Icon icon={arrowForwardOutline}/>}
                                                >
                                                    Continue
                                                </LoadingButton>
                                            </Stack>
                                        ))}
                                    </>
                                ) : (
                                    <card>
                                        <Stack>
                                            <Typography id="transition-modal-title" variant="h5" sx={{ borderBottom: '1px dashed #b1b9be', paddingBottom:3 }}>
                                                Your Registered Licences!
                                            </Typography>
                                        <img src="/static/illustrations/no.png" alt="login"/>
                                        <Typography variant="h4" gutterBottom textAlign='center' color='#a9a9a9'>No Data
                                            Found</Typography>
                                        </Stack>
                                    </card>
                                )}
                            </>
                        }
                    </>
                </Card>
            </Stack>
        </Stack>
    );
}

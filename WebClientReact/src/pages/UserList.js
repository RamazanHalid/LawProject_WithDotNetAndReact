// material
import {styled} from '@mui/material/styles';
import {
    Avatar,
    Card,
    Container, IconButton,
    Paper,
    Stack,
    Table, TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Typography
} from '@mui/material';
// layouts
// components
import Page from '../components/Page';
import React, {useEffect, useState} from "react";
import PopupMessageService from "../services/popupMessage.service";
import LicenceUsersService from "../services/licenceUsers.service";
import {Global} from "../Global";
import {LoadingButton} from "@mui/lab";
import {Icon} from "@iconify/react";
import arrowForwardOutline from "@iconify/icons-eva/arrow-forward-outline";
import {useNavigate} from "react-router-dom";
import CircularProgress from "@mui/material/CircularProgress";
import Scrollbar from "../components/Scrollbar";
import {format} from "date-fns";
import arrowBackOutline from '@iconify/icons-eva/arrow-back-outline';
// ----------------------------------------------------------------------

const RootStyle = styled(Page)(({theme}) => ({
    [theme.breakpoints.up('md')]: {
        display: 'flex'
    }
}));

// ----------------------------------------------------------------------

export default function UserList() {
    const [licenceUsers, setLicenceUsers] = useState([]);
    const [isLoading, setIsLoading] = useState(true);
    const popupMessageService = new PopupMessageService();
    const licenceUsersService = new LicenceUsersService();
    const catchMessagee = Global.catchMessage;
    const navigate = useNavigate();

    const getAllUserLists = () => {
        licenceUsersService
            .getAll()
            .then(
                (response) => {
                    setLicenceUsers(response.data.Data);
                    console.log(response.data.Data)
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

    useEffect(() => {
        getAllUserLists();
    }, []);

    return (
        <RootStyle title="User List | MediLaw">
            <Container>
                <Stack direction="row" alignItems="center" justifyContent="flex-start" mb={4}>
                    <IconButton onClick={() => navigate(-1)} sx={{ mr: 3, color: 'text.primary', bottom:3 }} size="large">
                        <Icon icon={arrowBackOutline} />
                    </IconButton>
                    <Typography variant="h4" gutterBottom>
                        User List
                    </Typography>
                </Stack>
                <Card sx={{marginTop: 6, maxWidth: 1000, marginLeft: 4}}>
                    <Scrollbar>
                        {isLoading === true ?
                            <Stack sx={{color: 'grey.500', padding: 10}} spacing={2} direction="row"
                                   justifyContent='center'>
                                <CircularProgress color="inherit"/>
                            </Stack>
                            :
                            <>
                                {licenceUsers.length > 0 ? (
                                    <TableContainer component={Paper}>
                                        <Table sx={{minWidth: 500}} aria-label="simple table">
                                            <TableHead>
                                                <TableRow>
                                                    <TableCell sx={{paddingLeft: 7}}>Title</TableCell>
                                                    <TableCell align="left">Name Surname</TableCell>
                                                    <TableCell align="left">Cell Phone</TableCell>
                                                    <TableCell align="left">Start Date</TableCell>
                                                    <TableCell align="left">Permission</TableCell>
                                                    <TableCell align="left"/>
                                                </TableRow>
                                            </TableHead>
                                            <TableBody>
                                                <>
                                                    {licenceUsers.map((row) => (
                                                        <TableRow
                                                            key={row.LicenceUserId}
                                                            sx={{'&:last-child td, &:last-child th': {border: 0}}}
                                                        >
                                                            <TableCell component="th" scope="row" sx={{paddingLeft: 7}}>
                                                                {row.User.Title}
                                                            </TableCell>
                                                            <TableCell component="th" scope="row">
                                                                {row.User.FirstName} {row.User.LastName}
                                                            </TableCell>
                                                            <TableCell component="th" scope="row">
                                                                {row.User.CellPhone}
                                                            </TableCell>
                                                            <TableCell component="th" scope="row" sx={{paddingLeft: 2}}>
                                                                {format(new Date(row.StartDate), 'dd/MM/yyyy')}
                                                            </TableCell>
                                                            <TableCell align="left">
                                                                {row.IsUserAccept === false ?
                                                                    <LoadingButton
                                                                        disabled
                                                                        sx={{height: 30, backgroundColor: '#b1b9be'}}
                                                                        type="button"
                                                                        size="medium"
                                                                        variant="contained"
                                                                        loading={false}
                                                                    >
                                                                        Waiting for Authorization!
                                                                    </LoadingButton>
                                                                    :
                                                                    <LoadingButton
                                                                        onClick={() => {
                                                                            navigate('/dashboard/licenceSettings/userList/permission/' + row.User.Id)
                                                                        }}
                                                                        sx={{height: 30}}
                                                                        type="button"
                                                                        size="medium"
                                                                        variant="contained"
                                                                        loading={false}
                                                                        startIcon={<Icon icon={arrowForwardOutline}/>}
                                                                    >
                                                                        Give Permission!
                                                                    </LoadingButton>
                                                                }
                                                            </TableCell>
                                                            <TableCell align="left"/>
                                                        </TableRow>
                                                    ))}
                                                </>
                                            </TableBody>
                                        </Table>
                                    </TableContainer>
                                ) : (
                                    <TableCell>
                                    <img src="/static/illustrations/no.png" alt="login"/>
                                    <Typography variant="h3" gutterBottom textAlign='center' color='#a9a9a9'>No
                                    Data Found</Typography>
                                    </TableCell>
                                )}
                            </>
                        }
                    </Scrollbar>
                </Card>
            </Container>
        </RootStyle>
    );
}

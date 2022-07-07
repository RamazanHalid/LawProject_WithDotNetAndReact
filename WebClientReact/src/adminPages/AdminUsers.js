import {Icon} from '@iconify/react';
import React, {useEffect, useState} from 'react';
import CircularProgress from '@mui/material/CircularProgress';
// material
import {
    Card,
    Table,
    Stack,
    Button,
    TableRow,
    TableBody,
    Container,
    Typography,
    TableContainer,
    Paper,
    TableHead, TablePagination, Box, TextField, InputAdornment, Collapse, IconButton, Avatar,
} from '@mui/material';
// components
import Page from '../components/Page';
import Scrollbar from '../components/Scrollbar';
import PopupMessageService from '../services/popupMessage.service';
import {Global} from "../Global";
import FormControl from "@mui/material/FormControl";
import MenuItem from "@mui/material/MenuItem";
import ToggleOffOutlinedIcon from "@mui/icons-material/ToggleOffOutlined";
import TableCell, {tableCellClasses} from '@mui/material/TableCell';
import {styled} from '@mui/material/styles';
import optionsOutline from '@iconify/icons-eva/options-outline';
import EmailOutlinedIcon from '@mui/icons-material/EmailOutlined';
import PersonOutlineOutlinedIcon from '@mui/icons-material/PersonOutlineOutlined';
import UserService from "../services/user.service";
import LocalPhoneOutlinedIcon from '@mui/icons-material/LocalPhoneOutlined';
import layersOutline from "@iconify/icons-eva/layers-outline";
import {useNavigate} from "react-router-dom";
import ChevronLeftOutlinedIcon from "@mui/icons-material/ChevronLeftOutlined";
import ChevronRightOutlinedIcon from "@mui/icons-material/ChevronRightOutlined";
// ----------------------------------------------------------------------

const StyledTableCell = styled(TableCell)(({theme}) => ({
    [`&.${tableCellClasses.head}`]: {
        backgroundColor: theme.palette.primary.main,
        color: theme.palette.common.white,
    },
    [`&.${tableCellClasses.body}`]: {
        fontSize: 14,
    },
}));

const StyledTableRow = styled(TableRow)(({theme}) => ({
    '&:nth-of-type(odd)': {
        backgroundColor: theme.palette.action.hover,
    },
    // hide last border
    '&:last-child td, &:last-child th': {
        border: 0,
    },
}));

export default function AdminLicences() {
    const [allUsers, setAllUsers] = useState([]);
    const [isLoading, setIsLoading] = useState(true);
    const [pageNumber, setPageNumber] = useState(0);
    const [pageSize, setPageSize] = useState(3);
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [cellPhone, setCellPhone] = useState("");
    const [email, setEmail] = useState("");
    const [isActive, setIsActive] = useState(-1);
    const userService = new UserService();
    const popupMessageService = new PopupMessageService();
    const catchMessagee = Global.catchMessage;
    const navigate = useNavigate();

    const getAllUsers = (firstName, lastName, cellPhone, isActive, email, pageNumber, pageSize) => {
        userService.getAllUsersAsAdmin(firstName, lastName, cellPhone, isActive, email, pageNumber, pageSize).then(
            (result) => {
                if (result.data.Success) {
                    setAllUsers(result.data.Data);
                    setIsLoading(false)
                }
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    };

    const previousValues = () => {
        if (pageNumber > 0 && allUsers.length > 0) {
            getAllUsers(firstName, lastName, cellPhone, isActive, email,pageNumber - 1, pageSize)
            setPageNumber(pageNumber - 1)
        }
    }

    const nextValues = () => {
        if (allUsers.length >= 3) {
            getAllUsers(firstName, lastName, cellPhone, isActive, email,pageNumber + 1, pageSize)
            setPageNumber(pageNumber + 1)
        }
    }

    const appearFilter = () => {
        getAllUsers(firstName, lastName, cellPhone, isActive, email, pageNumber, pageSize)
    }

    useEffect(() => {
        getAllUsers(firstName, lastName, cellPhone, isActive, email, pageNumber, pageSize);
        console.log(allUsers)
    }, []);

    return (
        <Page title="Users | MediLaw">
            <Container>
                <Stack direction="row" alignItems="center" justifyContent="space-between" mb={4}>
                    <Typography variant="h4" gutterBottom>
                        Users
                    </Typography>
                    <Button onClick={appearFilter} variant="contained" startIcon={<Icon icon={optionsOutline}/>}>
                        Filter
                    </Button>
                </Stack>
                <Stack mb={4} flexDirection="row" alignItems="center" justifyContent="space-around">
                    <Stack mb={5} justifyContent="space-around">
                        <Typography variant="body1" gutterBottom mb={2}>
                            First Name
                        </Typography>
                            <Box sx={{minWidth: 300}}>
                                <FormControl fullWidth size="small">
                                    <TextField
                                        size='small'
                                        label="First Name"
                                        value={firstName}
                                        onChange={(e) => setFirstName(e.target.value)}
                                        key={Math.random().toString(36).substr(2, 9)}
                                        InputProps={{
                                            startAdornment: (
                                                <InputAdornment position="start">
                                                    <PersonOutlineOutlinedIcon/>
                                                </InputAdornment>
                                            )
                                        }}
                                    />
                                </FormControl>
                            </Box>
                    </Stack>
                    <Stack mb={5} justifyContent="space-around">
                        <Typography variant="body1" gutterBottom mb={2}>
                            Last Name
                        </Typography>
                            <Box sx={{minWidth: 300}}>
                                <FormControl fullWidth size="small">
                                    <TextField
                                        size='small'
                                        label="Last Name"
                                        value={lastName}
                                        key={Math.random().toString(36).substr(2, 9)}
                                        onChange={(e) => setLastName(e.target.value)}
                                        InputProps={{
                                            startAdornment: (
                                                <InputAdornment position="start">
                                                    <PersonOutlineOutlinedIcon/>
                                                </InputAdornment>
                                            )
                                        }}
                                   />
                                </FormControl>
                            </Box>
                    </Stack>
                    <Stack mb={5} justifyContent="space-around">
                        <Typography variant="body1" gutterBottom mb={2}>
                            CellPhone
                        </Typography>
                        <Box sx={{minWidth: 300}}>
                            <FormControl fullWidth size="small">
                                <TextField
                                    size='small'
                                    value={cellPhone}
                                    key={Math.random().toString(36).substr(2, 9)}
                                    label="CellPhone"
                                    onChange={(e) => setCellPhone(e.target.value)}
                                    InputProps={{
                                        startAdornment: (
                                            <InputAdornment position="start">
                                                <LocalPhoneOutlinedIcon/>
                                            </InputAdornment>
                                        )
                                    }}
                                />
                            </FormControl>
                        </Box>
                    </Stack>
                </Stack>
                <Stack mb={5} marginTop={-7} flexDirection="row" alignItems="center" justifyContent="flex-start">
                    <Stack mb={5} ml={4}>
                        <Typography variant="body1" gutterBottom mb={2}>
                            Status
                        </Typography>
                        <Box sx={{minWidth: 300}}>
                            <FormControl fullWidth size="small">
                                <TextField
                                    select
                                    size='small'
                                    value={isActive}
                                    key={Math.random().toString(36).substr(2, 9)}
                                    label="Status"
                                    onChange={(e) => setIsActive(e.target.value)}
                                    InputProps={{
                                        startAdornment: (
                                            <InputAdornment position="start">
                                                <ToggleOffOutlinedIcon/>
                                            </InputAdornment>
                                        )
                                    }}
                                >
                                    <MenuItem key={Math.random().toString(36).substr(2, 9)}
                                              value={-1}>All</MenuItem>
                                    <MenuItem key={Math.random().toString(36).substr(2, 9)} value={1}>
                                        Active
                                    </MenuItem>
                                    <MenuItem key={Math.random().toString(36).substr(2, 9)} value={0}>
                                        Passive
                                    </MenuItem>
                                </TextField>
                            </FormControl>
                        </Box>
                    </Stack>
                    <Stack mb={5} ml={7.5}>
                        <Typography variant="body1" gutterBottom mb={2}>
                            Email
                        </Typography>
                            <Box sx={{minWidth: 300}}>
                                <FormControl fullWidth size="small">
                                    <TextField
                                        size='small'
                                        label="Email"
                                        value={email}
                                        key={Math.random().toString(36).substr(2, 9)}
                                        onChange={(event) => setEmail(event.target.value)}
                                        InputProps={{
                                            startAdornment: (
                                                <InputAdornment position="start">
                                                    <EmailOutlinedIcon/>
                                                </InputAdornment>
                                            )
                                        }}
                                    />
                                </FormControl>
                            </Box>
                    </Stack>
                </Stack>
                <Card sx={{marginTop: -5}}>
                    <Scrollbar>
                        {isLoading === true ?
                            <Stack sx={{color: 'grey.500', padding: 10}} spacing={2} direction="row"
                                   justifyContent='center'>
                                <CircularProgress color="inherit"/>
                            </Stack>
                            :
                            <>
                                {allUsers.length > 0 ? (
                                    <TableContainer component={Paper}>
                                        <Table sx={{minWidth: 650}} aria-label="customized table">
                                            <TableHead>
                                                <TableRow>
                                                    <StyledTableCell
                                                        sx={{paddingLeft: 7}}>Avatar</StyledTableCell>
                                                    <StyledTableCell align="left">Full Name</StyledTableCell>
                                                    <StyledTableCell align="left">Cellphone</StyledTableCell>
                                                    <StyledTableCell align="left">Email</StyledTableCell>
                                                    <StyledTableCell align="left">City / Country</StyledTableCell>
                                                    <StyledTableCell align="left">Details</StyledTableCell>
                                                </TableRow>
                                            </TableHead>
                                            <TableBody>
                                                <>

                                                    {allUsers.map((row) => (
                                                        <StyledTableRow
                                                            key={row.Id}
                                                            sx={{'&:last-child td, &:last-child th': {border: 0}}}>
                                                            <StyledTableCell component="th" scope="row"
                                                                             sx={{paddingLeft: 7}}>
                                                                <Avatar
                                                                    src={'https://webapi.emlakofisimden.com/' + row.ProfileImage}
                                                                    alt="photoURL"/>
                                                            </StyledTableCell>
                                                            <StyledTableCell component="th" scope="row">
                                                                {row.FirstName} {row.LastName}
                                                            </StyledTableCell>
                                                            <StyledTableCell component="th" scope="row">
                                                                {row.CellPhone}
                                                            </StyledTableCell>
                                                            <StyledTableCell component="th" scope="row">
                                                                {row.Email}
                                                            </StyledTableCell>
                                                            <StyledTableCell component="th" scope="row">
                                                                {row.City} / {row.Country}
                                                            </StyledTableCell>
                                                            <StyledTableCell align="left">
                                                                <Button
                                                                    variant="contained"
                                                                    onClick={() => navigate('/adminDashboard/users/usersDetails/' + row.Id)}
                                                                    startIcon={<Icon icon={layersOutline}/>}
                                                                >
                                                                    Details
                                                                </Button>
                                                            </StyledTableCell>
                                                        </StyledTableRow>
                                                    ))}

                                                </>
                                            </TableBody>
                                        </Table>
                                        <Stack direction="row" alignItems="center" justifyContent="space-between" marginLeft={98}>
                                            <Typography sx={{fontSize: 12, paddingTop: 0.8}} gutterBottom color='#637281'>Tap to change the page :</Typography>
                                            <Box sx={{display: 'flex', alignItems: 'center', marginRight:5}}>
                                                <Box sx={{m: 0, position: 'relative'}}>
                                                    <IconButton onClick={previousValues}>
                                                        <ChevronLeftOutlinedIcon sx={{width: 27, height: 27}}/>
                                                    </IconButton>
                                                </Box>
                                                <Box sx={{m: 0, position: 'relative', marginLeft: 0.5}}>
                                                    <IconButton onClick={nextValues}>
                                                        <ChevronRightOutlinedIcon sx={{width: 27, height: 27}}/>
                                                    </IconButton>
                                                </Box>
                                            </Box>
                                        </Stack>
                                    </TableContainer>
                                ) : (
                                    <TableCell sx={{width: '40%'}}>
                                        <img src="/static/illustrations/no.png" alt="login"/>
                                        <Typography variant="h3" gutterBottom textAlign='center'
                                                    color='#a9a9a9'>No Data
                                            Found</Typography>
                                    </TableCell>
                                )}
                            </>
                        }
                    </Scrollbar>
                </Card>
            </Container>
        </Page>
    );
}

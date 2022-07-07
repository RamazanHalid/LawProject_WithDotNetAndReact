// material
import {styled} from '@mui/material/styles';
import {
    Avatar,
    Box, Button,
    Container, IconButton,
    InputAdornment,
    Paper,
    Stack,
    Table, TableBody, TableCell,
    TableContainer, TableHead, TableRow,
    TextField,
    Typography
} from '@mui/material';
// components
import Page from '../components/Page';
import LicenceSettings from "./LicenceSettings";
import {useEffect, useState} from "react";
import {Global} from "../Global";
import PersonTypesService from "../services/personTypes.service";
import PaymentsService from "../services/payments.service";
import LicencesService from "../services/licences.service";
import CityService from "../services/city.service";
import CountryService from "../services/country.service";
import PopupMessageService from "../services/popupMessage.service";
import UserService from "../services/user.service";
import LicenceUsersService from "../services/licenceUsers.service";
import CloseIcon from "@material-ui/icons/Close";
import PhoneInTalkOutlinedIcon from "@mui/icons-material/PhoneInTalkOutlined";
import account from "../_mocks_/account";
import CircularProgress from "@mui/material/CircularProgress";
import {Icon} from "@iconify/react";
import arrowBackOutline from "@iconify/icons-eva/arrow-back-outline";
import {useNavigate} from "react-router-dom";
// ----------------------------------------------------------------------

const RootStyle = styled(Page)(({theme}) => ({
    [theme.breakpoints.up('md')]: {
        display: 'flex'
    }
}));

// ----------------------------------------------------------------------

export default function AddUsers() {

    const [userCellPhone, setUserCellPhone] = useState(true);
    const [allUsers, setAllusers] = useState([]);
    const [isLoading, setIsLoading] = useState(false);
    const catchMessagee = Global.catchMessage;
    const licenceUser = new LicenceUsersService()
    const popMessage = new PopupMessageService()
    const userService = new UserService()
    const navigate = useNavigate();

    function getInputCellPhone(cellPhone) {
        setUserCellPhone(cellPhone)
    }

    function GetAllUsers() {
        userService.getAll().then(result => {
            setAllusers(result.data.Data);
        }, error => {
            console.log(error.response);
        }).catch(() => {
            popMessage.AlertErrorMessage(catchMessagee)
        })
    }

    function ListAllUsers() {
        let newList = []
        if (userCellPhone.length > 3) {
            newList = allUsers
            return newList.filter(r => r.CellPhone.startsWith(userCellPhone));
        }
        return newList
    }

    function SendRequest(userId) {
        licenceUser.add(userId).then(result => {
            popMessage.AlertSuccessMessage(result.data.Message)
            GetAllUsers()
        }, error => {
            console.log(error.response.data);
        }).catch(() => {
            popMessage.AlertErrorMessage(catchMessagee)
        })
    }

    useEffect(() => {
        GetAllUsers();
    }, [])
    return (
        <RootStyle title="Users | MediLaw">
            <Container>
                <Stack mb={5} flexDirection="row" justifyContent='flex-start'>
                    <IconButton onClick={() => navigate(-1)} sx={{ mr: 3, color: 'text.primary', bottom:7 }} size="large">
                        <Icon icon={arrowBackOutline} />
                    </IconButton>
                    <Typography variant="h4" gutterBottom>
                        Users
                    </Typography>
                </Stack>
                <Stack spacing={2}>
                    <Stack mb={0} alignItems="center" justifyContent="space-around">
                        <Stack mb={3} mr={57} justifyContent="flex-end">
                            <Box sx={{minWidth: 400}}>
                                <TextField
                                    autoFocus
                                    fullWidth
                                    type="number"
                                    size="small"
                                    label="Cell Phone"
                                    value={userCellPhone}
                                    onChange={(e) => getInputCellPhone(e.target.value)}
                                    InputProps={{
                                        startAdornment: (
                                            <InputAdornment position="start">
                                                <PhoneInTalkOutlinedIcon/>
                                            </InputAdornment>
                                        )
                                    }}
                                />
                            </Box>
                        </Stack>
                        {isLoading === true ?
                            <Stack sx={{color: 'grey.500', padding: 10}} spacing={2} direction="row"
                                   justifyContent='center'>
                                <CircularProgress color="inherit"/>
                            </Stack>
                            :
                            <>
                                {ListAllUsers(allUsers).length > 0 ? (
                                        <Box
                                            sx={{
                                                left: '59%',
                                                position: 'absolute',
                                                top: '52%',
                                                transform: 'translate(-50%, -50%)',
                                                minWidth: 850,
                                                maxWidth: 850,
                                                minHeight: 200,
                                                backgroundColor: 'background.paper',
                                                border: '2px solid #fff',
                                                boxShadow: 24,
                                                p: 4,
                                                borderRadius: 2
                                            }}
                                        >
                                            <TableContainer component={Paper}>
                                                <Table sx={{}} aria-label="simple table">
                                                    <TableHead>
                                                        <TableRow>
                                                            <TableCell sx={{paddingLeft: 5}}>Image</TableCell>
                                                            <TableCell align="left">Title</TableCell>
                                                            <TableCell align="left">Name Surname</TableCell>
                                                            <TableCell align="left">Cell Phone</TableCell>
                                                            <TableCell align="left">Add User</TableCell>
                                                            <TableCell align="left"/>
                                                        </TableRow>
                                                    </TableHead>
                                                    <TableBody>
                                                        <>
                                                            {ListAllUsers(allUsers).map((row) => (
                                                                <TableRow
                                                                    key={row.Id}
                                                                    sx={{'&:last-child td, &:last-child th': {border: 0}}}
                                                                >
                                                                    <TableCell component="th" scope="row"
                                                                               sx={{paddingLeft: 5}}>
                                                                        <Avatar src={account.photoURL} alt="photoURL"/>
                                                                    </TableCell>
                                                                    <TableCell component="th" scope="row">
                                                                        {row.Title}
                                                                    </TableCell>
                                                                    <TableCell component="th" scope="row">
                                                                        {row.FirstName} {row.LastName}
                                                                    </TableCell>
                                                                    <TableCell component="th" scope="row">
                                                                        {row.CellPhone}
                                                                    </TableCell>
                                                                    <TableCell component="th" scope="row">
                                                                        <Button
                                                                            size="small"
                                                                            type="submit"
                                                                            variant="contained"
                                                                            onClick={() => SendRequest(row.Id)}
                                                                        >Send Request! </Button>
                                                                    </TableCell>

                                                                </TableRow>
                                                            ))}
                                                        </>
                                                    </TableBody>
                                                </Table>
                                            </TableContainer>
                                        </Box>
                                    ) :
                                    <Box
                                        sx={{
                                            left: '59%',
                                            position: 'absolute',
                                            top: '60%',
                                            transform: 'translate(-50%, -50%)',
                                            minWidth: 850,
                                            backgroundColor: 'background.paper',
                                            border: '2px solid #fff',
                                            boxShadow: 24,
                                            p: 4,
                                            borderRadius: 2
                                        }}
                                    >
                                        <img src="/static/illustrations/search.png" alt="login"/>
                                        <Typography variant="h6" textAlign='center' color='#534ae8'>Please search for a
                                            phone number!</Typography>
                                    </Box>
                                }
                            </>
                        }
                    </Stack>
                </Stack>
            </Container>
        </RootStyle>
    );
}

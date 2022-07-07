// material
import {styled} from '@mui/material/styles';
import {
    Avatar,
    Card,
    Container,
    IconButton,
    Stack,
    Typography
} from '@mui/material';
// components
import Page from '../components/Page';
import React, {useEffect, useState} from "react";
import {useNavigate, useParams} from "react-router-dom";
import PopupMessageService from "../services/popupMessage.service";
import {Global} from "../Global";
import {Icon} from "@iconify/react";
import arrowBackOutline from "@iconify/icons-eva/arrow-back-outline";
import CircularProgress from "@mui/material/CircularProgress";
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import LocalPhoneOutlinedIcon from '@mui/icons-material/LocalPhoneOutlined';
import FaceOutlinedIcon from '@mui/icons-material/FaceOutlined';
import SubtitlesOutlinedIcon from '@mui/icons-material/SubtitlesOutlined';
import EmailOutlinedIcon from '@mui/icons-material/EmailOutlined';
import MapsHomeWorkOutlinedIcon from '@mui/icons-material/MapsHomeWorkOutlined';
import LanguageOutlinedIcon from '@mui/icons-material/LanguageOutlined';
import PersonPinOutlinedIcon from '@mui/icons-material/PersonPinOutlined';
import UserService from "../services/user.service";
// ----------------------------------------------------------------------
const RootStyle = styled(Page)(({theme}) => ({
    [theme.breakpoints.up('md')]: {
        display: 'flex'
    }
}));
// ----------------------------------------------------------------------

export default function AdminUsersDetails() {
    const {id} = useParams()
    const popupMessageService = new PopupMessageService();
    const userService = new UserService();
    const catchMessagee = Global.catchMessage;
    const [lastName, setLastName] = useState("")
    const [firstName, setFirstName] = useState("")
    const [email, setEmail] = useState("")
    const [city, setCity] = useState("")
    const [country, setCountry] = useState("")
    const[title, setTitle] = useState("")
    const [profileImage, setProfileImage] = useState("")
    const [isLoading, setIsLoading] = useState(true);
    const today = new Date();
    const date = today.setDate(today.getDate());
    const defaultValue = new Date(date).toISOString().split('T')[0]
    const [cellphone, setCellPhone] = useState(defaultValue);
    const navigate = useNavigate();

    const getAllCaseUpdateHistory = (Lid) => {
        userService.getByUserIdAsAdmin(Lid).then(
            (result) => {
                let details = result.data.Data
                setFirstName(details.FirstName)
                setLastName(details.LastName)
                setCellPhone(details.CellPhone)
                setEmail(details.Email)
                setCity(details.City.CityName)
                setCountry(details.City.Country.CountryName)
                setTitle(details.Title)
                setProfileImage(details.ProfileImage)
                setIsLoading(false)
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    };

    useEffect(() => {
        getAllCaseUpdateHistory(id)
    }, [])

    return (
        <RootStyle title="Users Details | MediLaw">
            <Container>
                <Stack direction="row" alignItems="center" justifyContent="flex-start" mb={4}>
                    <IconButton onClick={() => navigate(-1)} sx={{mr: 3, color: 'text.primary', bottom: 3}}
                                size="large">
                        <Icon icon={arrowBackOutline}/>
                    </IconButton>
                    <Typography variant="h4" gutterBottom>Users Details</Typography>
                </Stack>
                <Stack flexDirection='row'>
                    {isLoading === true ?
                        <Stack sx={{color: 'grey.500', paddingLeft: 60, paddingTop: 25}} spacing={2}
                               direction="row"
                               justifyContent='center' alignSelf='center' left='50%'>
                            <CircularProgress color="inherit"/>
                        </Stack>
                        :
                        <>
                            <Card sx={{
                                width: '100%',
                                maxWidth: 840,
                                bgcolor: 'background.paper',
                                marginLeft: 14,
                                marginTop: 3
                            }}>
                                <List
                                    sx={{
                                        width: '100%',
                                        maxWidth: 830,
                                        bgcolor: 'background.paper',
                                        marginLeft: 0.5,
                                        padding: 2
                                    }}>
                                    <ListItem sx={{
                                        backgroundColor: '#f7f7f7',
                                        padding: 2,
                                        border: '6px solid #fff',
                                    }}>
                                        <ListItemIcon>
                                            <FaceOutlinedIcon/>
                                        </ListItemIcon>
                                        <ListItemText id="switch-list-label-bluetooth" primary="Avatar :"/>
                                        <Avatar
                                            sx={{width: 35, height: 35}}
                                            src={'https://webapi.emlakofisimden.com/' + profileImage}
                                            alt="photoURL"/>
                                    </ListItem>
                                    <ListItem sx={{paddingLeft: 2.7}}>
                                        <ListItemIcon>
                                            <PersonPinOutlinedIcon/>
                                        </ListItemIcon>
                                        <ListItemText id="switch-list-label-bluetooth" primary="Full Name :"/>
                                        <Typography
                                            sx={{display: 'inline'}}
                                            component="span"
                                            variant="body1"
                                            color="text.primary"
                                        >
                                            {firstName} {lastName}
                                        </Typography>
                                    </ListItem>
                                    <ListItem sx={{ backgroundColor: '#f7f7f7',
                                        padding: 2,
                                        border: '6px solid #fff'}}>
                                        <ListItemIcon>
                                            <SubtitlesOutlinedIcon/>
                                        </ListItemIcon>
                                        <ListItemText id="switch-list-label-bluetooth" primary="Title :"/>
                                        <Typography
                                            sx={{display: 'inline'}}
                                            component="span"
                                            variant="body1"
                                            color="text.primary"
                                        >
                                            {title}
                                        </Typography>
                                    </ListItem>
                                    <ListItem sx={{paddingLeft: 2.7}}>
                                        <ListItemIcon>
                                            <EmailOutlinedIcon/>
                                        </ListItemIcon>
                                        <ListItemText id="switch-list-label-bluetooth" primary="Email :"/>
                                        <Typography
                                            sx={{display: 'inline'}}
                                            component="span"
                                            variant="body1"
                                            color="text.primary"
                                        >
                                            {email}
                                        </Typography>
                                    </ListItem>
                                    <ListItem sx={{backgroundColor: '#f7f7f7',
                                        padding: 2,
                                        border: '6px solid #fff'}}>
                                        <ListItemIcon>
                                            <LocalPhoneOutlinedIcon/>
                                        </ListItemIcon>
                                        <ListItemText id="switch-list-label-bluetooth" primary="Cellphone :"/>
                                        <Typography
                                            sx={{display: 'inline'}}
                                            component="span"
                                            variant="body1"
                                            color="text.primary"
                                        >
                                            {cellphone}
                                        </Typography>
                                    </ListItem>
                                    <ListItem sx={{ paddingLeft: 2.7}}>
                                        <ListItemIcon>
                                            <LanguageOutlinedIcon/>
                                        </ListItemIcon>
                                        <ListItemText id="switch-list-label-bluetooth" primary="Country / City :"/>
                                        <Typography
                                            sx={{display: 'inline'}}
                                            component="span"
                                            variant="body1"
                                            color="text.primary"
                                        >
                                            {country} / {city}
                                        </Typography>
                                    </ListItem>
                                </List>
                            </Card>
                        </>
                    }
                </Stack>
            </Container>
        </RootStyle>
    );
}
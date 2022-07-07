import React, {useEffect, useRef, useState} from 'react';
import PhoneInTalkOutlinedIcon from '@mui/icons-material/PhoneInTalkOutlined';
import SubtitlesOutlinedIcon from '@mui/icons-material/SubtitlesOutlined';
import PublicOutlinedIcon from '@mui/icons-material/PublicOutlined';
import BusinessOutlinedIcon from '@mui/icons-material/BusinessOutlined';
import EmailOutlinedIcon from '@mui/icons-material/EmailOutlined';
import {useNavigate} from 'react-router-dom';

// material
import PersonOutlineOutlinedIcon from '@mui/icons-material/PersonOutlineOutlined';
import {Stack, TextField, InputAdornment, Avatar, Box, Typography, Container, Card, Switch} from '@mui/material';
import {LoadingButton} from '@mui/lab';
import PopupMessageService from "../../../services/popupMessage.service";
import ProfileService from "../../../services/profile.service";
import FormControl from "@mui/material/FormControl";
import MenuItem from "@mui/material/MenuItem";
import {Global} from "../../../Global";
import CityService from "../../../services/city.service";
import CountryService from "../../../services/country.service";
import CircularProgress from "@mui/material/CircularProgress";
import Page from "../../Page";
import AddAPhotoOutlinedIcon from '@mui/icons-material/AddAPhotoOutlined';
import UserProfileAvatarService from "../../../services/userProfileAvatar.service";
import {value} from "lodash/seq";
import account from "../../../_mocks_/account";
import AuthService from "../../../services/auth.service";
// ----------------------------------------------------------------------

export default function ProfileForm() {
    const navigate = useNavigate();
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [cellPhone, setCellPhone] = useState('');
    const [email, setEmail] = useState('');
    const [title, setTitle] = useState('');
    const [profileImage, setProfileImage] = useState(0);
    const [avatar, setAvatar] = useState([]);
    const [p, setp] = useState("");
    const [isLoading, setIsLoading] = useState(false);

    const [allCountries, setAllCountries] = useState([]);
    const [allCities, setAllCities] = useState([]);
    const [selectedCountryId, setSelectedCountryId] = useState(0)
    const [selectedCityId, setSelectedCityId] = useState(0)

    const profileService = new ProfileService();
    const popupMessageService = new PopupMessageService();
    const cityService = new CityService();
    const userProfileAvatarService = new UserProfileAvatarService();
    const countryService = new CountryService();
    const authService = new AuthService();
    const catchMessagee = Global.catchMessage;

    const Logout = () => {
        authService.logout();
        navigate('/login');
    };

    function userInfo() {
        profileService.getUserInfo().then(result => {
            if (result.data.Success) {
                let info = result.data.Data
                setFirstName(info.FirstName)
                setLastName(info.LastName)
                setTitle(info.Title)
                setEmail(info.Email)
                setSelectedCityId(info.City.CityId)
                setSelectedCountryId(info.City.Country.CountryId)
                setp(info.ProfileImage)
                setCellPhone(info.CellPhone)
            }
        })
    }

    const updateUserInfo = () => {
        let obj = {
            firstName: firstName,
            lastName: lastName,
            title: title,
            email: email,
            cityId: selectedCityId,
            countryId: selectedCountryId,
            userProfileAvatarId: profileImage,
        }
        let re = profileService.updateUserProfile(obj)
        re.then(
            (result) => {
                if (result.data.Success) {
                    userInfo()
                    setIsLoading(false)
                    popupMessageService.AlertSuccessMessage(result.data.Message)
                    Logout()
                }
            },
            (error) => {
                setIsLoading(false)
                popupMessageService.AlertErrorMessage(error.response.data.Message)
            }
        ).catch(() => {
            setIsLoading(false)
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    };

    function handleTatChange(TatId) {
        getAllCities(TatId)
        setSelectedCountryId(TatId)
    }

    function getAllCountries() {
        countryService.getAll().then(result => {
                setAllCountries(result.data.Data)
                setSelectedCountryId(result.data.Data[0].CountryId)
                getAllCities(result.data.Data[0].CountryId)
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    }

    const getUserAvatar = () => {
        userProfileAvatarService.getAll().then(
            (response) => {
                setAvatar(response.data.Data);
                const AvatarFromApi = response.data.Data;
                const list = [];
                AvatarFromApi.forEach((item) => {
                    list.push({
                        value: item.UserProfileAvatarId,
                        label: item.ProfileAvatarPath,
                        key: item.ProfileAvatarPath
                    });
                });
                setProfileImage(list[0].value)
                setAvatar(list);
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        )
            .catch(() => {
                popupMessageService.AlertErrorMessage(catchMessagee)
            });
    };

    function getAllCities(id) {
        cityService.getAll(id).then(result => {
                let id = result.data.Data[0].CityId
                setSelectedCityId(id)
                setAllCities(result.data.Data)
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    }

    useEffect(() => {
        userInfo();
        getAllCountries();
        getUserAvatar();
    }, []);


    return (
        <Page title="Profile | MediLaw">
            <Container>
                {authService.DoesHaveMandatoryClaim('LicenceOwner') ? (
                    <>
                <Stack direction="row" alignItems="center" justifyContent="space-between" mb={4}>
                    <Typography variant="h4" gutterBottom>
                        Profile
                    </Typography>
                </Stack>
                <Stack flexDirection='row' alignItems='space-between' sx={{marginBottom: '0%'}}>
                    <Card justifyContent="center" sx={{padding: 4, maxWidth: 300, minWidth: 300, marginLeft: 8}}>
                        <Stack ml={6.5} mt={3} sx={{
                            borderRadius: 10,
                            width: 130,
                            height: 130,
                            border: '1px dashed #b1b9be',
                            padding: '0.4em',
                            p: 4
                        }}>
                            <Avatar src={'https://webapi.emlakofisimden.com/' + p} alt="photoURL"
                                    sx={{width: 110, height: 110, right: '35%', bottom: '35%'}}/>
                        </Stack>
                        <Stack flexDirection='row' mt={4} sx={{border: '1px dashed #b1b9be', p: 1, borderRadius: 1.5, paddingTop: 3.3}}>
                            <AddAPhotoOutlinedIcon sx={{color: '#7f8181', marginRight: 1, width: 18, height: 18, marginLeft: 1}}/>
                            <Typography textAlign='center' fontSize={13} color='#7f8181'>Select Avatar :</Typography>
                        {avatar.length > 0 ? (
                            <Stack mt={-2.5} ml={2}>
                                <TextField
                                    sx={{maxWidth: 80}}
                                    variant="standard"
                                    select
                                    fullWidth
                                    value={profileImage}
                                    onChange={(event) => setProfileImage(event.target.value)}
                                    InputProps={{
                                        disableUnderline: true,
                                    }}
                                >
                                    {avatar.map((item) => (
                                        <MenuItem
                                            key={Math.random().toString(36).substr(2, 9)}
                                            value={item.value}
                                        >
                                            <Avatar src={'https://webapi.emlakofisimden.com/' + item.label}
                                                    alt="photoURL" sx={{width: 45, height: 45,}}/>
                                        </MenuItem>
                                    ))}
                                </TextField>
                            </Stack>
                        ) : null}
                        </Stack>
                    </Card>
                    <Card justifyContent="space-around" sx={{padding: 6, maxWidth: 600, marginLeft: 2}}>
                        <Stack mb={3} direction={{xs: 'column', sm: 'row'}} spacing={2}>
                            <TextField
                                fullWidth
                                label="First Name"
                                value={firstName}
                                onChange={(event) => setFirstName(event.target.value)}
                                InputProps={{
                                    startAdornment: (
                                        <InputAdornment position="start">
                                            <PersonOutlineOutlinedIcon/>
                                        </InputAdornment>
                                    )
                                }}
                            />
                            <TextField
                                fullWidth
                                label="Last Name"
                                value={lastName}
                                onChange={(event) => setLastName(event.target.value)}
                                InputProps={{
                                    startAdornment: (
                                        <InputAdornment position="start">
                                            <PersonOutlineOutlinedIcon/>
                                        </InputAdornment>
                                    )
                                }}
                            />
                        </Stack>
                        <Stack mb={3} justifyContent="space-around">
                            <Box sx={{minWidth: 400}}>
                                <TextField
                                    fullWidth
                                    label="Cell Phone"
                                    value={cellPhone}
                                    onChange={(event) => setCellPhone(event.target.value)}
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
                        <Stack mb={3} justifyContent="space-around">
                            <Box sx={{minWidth: 400}}>
                                <TextField
                                    fullWidth
                                    label="Email"
                                    value={email}
                                    onChange={(event) => setEmail(event.target.value)}
                                    InputProps={{
                                        startAdornment: (
                                            <InputAdornment position="start">
                                                <EmailOutlinedIcon/>
                                            </InputAdornment>
                                        )
                                    }}
                                />
                            </Box>
                        </Stack>
                        <Stack mb={3} justifyContent="space-around">
                            <Box sx={{minWidth: 400}}>
                                <TextField
                                    fullWidth
                                    label="Title"
                                    value={title}
                                    onChange={(event) => setTitle(event.target.value)}
                                    InputProps={{
                                        startAdornment: (
                                            <InputAdornment position="start">
                                                <SubtitlesOutlinedIcon/>
                                            </InputAdornment>
                                        )
                                    }}
                                />
                            </Box>
                        </Stack>
                        {allCountries.length > 0 ? (
                            <Stack mb={3} justifyContent="space-around">
                                <Box>
                                    <FormControl fullWidth>
                                        <TextField
                                            select
                                            label="Country"
                                            value={selectedCountryId}
                                            onChange={(e) => handleTatChange(e.target.value)}
                                            key={Math.random().toString(36).substr(2, 9)}
                                            InputProps={{
                                                startAdornment: (
                                                    <InputAdornment position="start">
                                                        <PublicOutlinedIcon/>
                                                    </InputAdornment>
                                                )
                                            }}
                                        >
                                            {allCountries.map((item) => (
                                                <MenuItem
                                                    key={Math.random().toString(36).substr(2, 9)}
                                                    value={item.CountryId}
                                                >
                                                    {item.CountryName}
                                                </MenuItem>
                                            ))}
                                        </TextField>
                                    </FormControl>
                                </Box>
                            </Stack>
                        ) : null}
                        {allCities.length > 0 ? (
                            <Stack mb={4} justifyContent="space-around">
                                <Box>
                                    <FormControl fullWidth>
                                        <TextField
                                            select
                                            label="City"
                                            value={selectedCityId}
                                            onChange={(e) => setSelectedCityId(e.target.value)}
                                            key={Math.random().toString(36).substr(2, 9)}
                                            InputProps={{
                                                startAdornment: (
                                                    <InputAdornment position="start">
                                                        <BusinessOutlinedIcon/>
                                                    </InputAdornment>
                                                )
                                            }}
                                        >
                                            {allCities.map((item) => (
                                                <MenuItem
                                                    key={Math.random().toString(36).substr(2, 9)}
                                                    value={item.CityId}
                                                >
                                                    {item.CityName}
                                                </MenuItem>
                                            ))}
                                        </TextField>
                                    </FormControl>
                                </Box>
                            </Stack>
                        ) : null}

                        <LoadingButton
                            fullWidth
                            size="large"
                            type="submit"
                            variant="contained"
                            onClick={() => {
                                setIsLoading(true)
                                updateUserInfo()
                            }}
                        >
                            {isLoading ? (
                                <>
                                    <CircularProgress color="inherit" size={20}/>
                                </>
                            ) : null}
                            Edit
                        </LoadingButton>
                    </Card>
                </Stack>
                    </>
                ): <Typography>Sorry, you don't have the authorization to perform this action!</Typography>}
            </Container>
        </Page>

    );
}

import * as Yup from 'yup';
import React, {useEffect, useState} from 'react';
import {Icon} from '@iconify/react';
import {useFormik, Form, FormikProvider} from 'formik';
import eyeOutline from '@iconify/icons-eva/eye-outline';
import eyeOffOutline from '@iconify/icons-eva/eye-off-outline';
import {useNavigate} from 'react-router-dom';
import NumberFormat from 'react-number-format';

// material
import PersonOutlineOutlinedIcon from '@mui/icons-material/PersonOutlineOutlined';
import VpnKeyOutlinedIcon from '@mui/icons-material/VpnKeyOutlined';
import SubtitlesOutlinedIcon from '@mui/icons-material/SubtitlesOutlined';
import PhoneOutlinedIcon from '@mui/icons-material/PhoneOutlined';
import EmailOutlinedIcon from '@mui/icons-material/EmailOutlined';

import {
    Stack,
    TextField,
    IconButton,
    InputAdornment,
    Box
} from '@mui/material';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import {LoadingButton} from '@mui/lab';
import CityService from '../../../services/city.service';
import AuthService from '../../../services/auth.service';
import CountryService from '../../../services/country.service';
import PopupMessageService from '../../../services/popupMessage.service';
import {Global} from '../../../Global';
import CircularProgress from "@mui/material/CircularProgress";
import PublicOutlinedIcon from '@mui/icons-material/PublicOutlined';
import BusinessOutlinedIcon from '@mui/icons-material/BusinessOutlined';
// ----------------------------------------------------------------------

export default function RegisterForm() {
    const navigate = useNavigate();
    const [showPassword, setShowPassword] = useState(false);
    const [showPasswordAgain, setShowPasswordAgain] = useState(false);
    const [isLoading, setIsLoading] = useState(false);

    const [valueR, setValueR] = useState('');
    const [cityValue, setCityValue] = useState(0);
    const [isCountrySelected, setIsCountrySelected] = useState(false);
    const catchMessagee = Global.catchMessage;
    const popupMessageService = new PopupMessageService();
    const authService = new AuthService();

    const [countries, setCountries] = useState([]);
    const [cities, setCities] = useState([]);
    const handleChange = (event) => {
        setValueR(event.target.value);
        setIsCountrySelected(true);
        const cityService = new CityService();
        cityService
            .getAll(event.target.value)
            .then((result) => {
                    const citiesFromApi = result.data.Data;
                    const list2 = [];
                    // eslint-disable-next-line no-restricted-syntax,guard-for-in
                    citiesFromApi.forEach((item) => {
                        list2.push({
                            value: item.CityId,
                            label: item.CityName,
                            key: item.CityName
                        });
                    });
                    setCities(list2);
                },
                (error) => {
                    popupMessageService.AlertErrorMessage(error.response.data.Message);
                })
            .catch((errors) => {
                popupMessageService.AlertErrorMessage(catchMessagee)
            });
    };

    const handleCitiesChange = (event) => {
        setCityValue(event.target.value);
    };
    useEffect(() => {
        const countryService = new CountryService();
        countryService
            .getAll()
            .then((result) => {
                    setCountries(result.data.Data);

                    const countriesFromApi = result.data.Data;
                    const list = [];
                    // eslint-disable-next-line no-restricted-syntax,guard-for-in
                    countriesFromApi.forEach((item) => {
                        list.push({
                            value: item.CountryId,
                            label: item.CountryName,
                            key: item.CountryName
                        });
                    });
                    setCountries(list);
                },
                (error) => {
                    popupMessageService.AlertErrorMessage(error.response.data.Message);
                })
            .catch((errors) => {
                popupMessageService.AlertErrorMessage(catchMessagee)
            });
    }, []);

    const RegisterSchema = Yup.object().shape({
        firstName: Yup.string()
            .min(2, 'Too Short!')
            .max(50, 'Too Long!')
            .required('First name required'),
        lastName: Yup.string().min(2, 'Too Short!').max(50, 'Too Long!').required('Last name required'),
        title: Yup.string().min(2, 'Too Short!').max(50, 'Too Long!').required('Title is required'),
        phone: Yup.string().required('Cell phone is required'),
        email: Yup.string().required('Email is required'),
        password: Yup.string().required('Password is required'),
        passwordAgain: Yup.string().required('Password confirmation is required')
    });

    const formik = useFormik({
        initialValues: {
            firstName: '',
            lastName: '',
            title: '',
            phone: '',
            email: '',
            password: '',
            passwordAgain: ''
        },
        validationSchema: RegisterSchema,
        onSubmit: () => {
            const popupMessageService = new PopupMessageService();
            if (formik.values.password !== formik.values.passwordAgain) {
                popupMessageService.AlertErrorMessage('Password and Confirm password have to be same!');
            } else {
                authService
                    .register(
                        formik.values.phone,
                        formik.values.password,
                        formik.values.firstName,
                        formik.values.lastName,
                        formik.values.email,
                        formik.values.title,
                        cityValue
                    )
                    .then(
                        (response) => {
                            if (response.data.Success) {
                                // if response is 200 (Ok)
                                console.log(response.data);
                                setIsLoading(false)
                                popupMessageService.AlertSuccessMessage('Registration was successful!');
                                navigate('/login');
                            } else {
                                setIsLoading(false)
                                console.log(response.data.Message);
                                popupMessageService.AlertErrorMessage(response.data.Message);
                            }
                        },
                        (error) => {
                            setIsLoading(false)
                            console.log(error.response.data);
                            popupMessageService.AlertErrorMessage(error.response.data.Message);
                        }
                    )
                    .catch(() => {
                        setIsLoading(false)
                        popupMessageService.AlertErrorMessage(catchMessagee)
                    });
            }
        }
    });

    const {errors, touched, handleSubmit, getFieldProps} = formik;

    return (
        <FormikProvider value={formik}>
            <Form autoComplete="off" noValidate onSubmit={handleSubmit}>
                <Stack spacing={3}>
                    <Stack direction={{xs: 'column', sm: 'row'}} spacing={2}>
                        <TextField
                            fullWidth
                            label="First Name"
                            {...getFieldProps('firstName')}
                            error={Boolean(touched.firstName && errors.firstName)}
                            helperText={touched.firstName && errors.firstName}
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
                            {...getFieldProps('lastName')}
                            error={Boolean(touched.lastName && errors.lastName)}
                            helperText={touched.lastName && errors.lastName}
                            InputProps={{
                                startAdornment: (
                                    <InputAdornment position="start">
                                        <PersonOutlineOutlinedIcon/>
                                    </InputAdornment>
                                )
                            }}
                        />
                    </Stack>
                    <Stack direction={{xs: 'column', sm: 'row'}} spacing={2}>
                    <TextField
                        fullWidth
                        label="Title"
                        {...getFieldProps('title')}
                        error={Boolean(touched.title && errors.title)}
                        helperText={touched.title && errors.title}
                        InputProps={{
                            startAdornment: (
                                <InputAdornment position="start">
                                    <SubtitlesOutlinedIcon/>
                                </InputAdornment>
                            )
                        }}
                    />
                    <TextField
                        fullWidth
                        type="number"
                        label="Cell phone"
                        placeholder="5xxxxxxxxx"
                        {...getFieldProps('phone')}
                        error={Boolean(touched.phone && errors.phone)}
                        helperText={touched.phone && errors.phone}
                        InputProps={{
                            startAdornment: (
                                <InputAdornment position="start">
                                    <PhoneOutlinedIcon/>
                                </InputAdornment>
                            )
                        }}
                    />
                    </Stack>
                    <TextField
                        fullWidth
                        type="email"
                        label="Email"
                        {...getFieldProps('email')}
                        error={Boolean(touched.email && errors.email)}
                        helperText={touched.email && errors.email}
                        InputProps={{
                            startAdornment: (
                                <InputAdornment position="start">
                                    <EmailOutlinedIcon/>
                                </InputAdornment>
                            )
                        }}
                    />
                    {countries.length > 0 ? (
                        <Box sx={{minWidth: 120}}>
                            <FormControl fullWidth>
                                <TextField
                                    select
                                    value={valueR}
                                    key={Math.random().toString(36).substr(2, 9)}
                                    label="Country"
                                    onChange={handleChange}
                                    InputProps={{
                                        startAdornment: (
                                            <InputAdornment position="start">
                                                <PublicOutlinedIcon/>
                                            </InputAdornment>
                                        )
                                    }}
                                >
                                    {countries.map((item) => (
                                        <MenuItem key={Math.random().toString(36).substr(2, 9)} value={item.value}>
                                            {item.label}
                                        </MenuItem>
                                    ))}
                                </TextField>
                            </FormControl>
                        </Box>
                    ) : null}

                    {cities.length > 0 && isCountrySelected ? (
                        <Box sx={{minWidth: 120}}>
                            <FormControl fullWidth>
                                <TextField
                                    select
                                    value={cityValue}
                                    key={Math.random().toString(36).substr(2, 9)}
                                    label="City"
                                    onChange={handleCitiesChange}
                                    InputProps={{
                                        startAdornment: (
                                            <InputAdornment position="start">
                                                <BusinessOutlinedIcon/>
                                            </InputAdornment>
                                        )
                                    }}
                                >
                                    {cities.map((item) => (
                                        <MenuItem key={Math.random().toString(36).substr(2, 9)} value={item.value}>
                                            {item.label}
                                        </MenuItem>
                                    ))}
                                </TextField>
                            </FormControl>
                        </Box>
                    ) : null}

                    <TextField
                        fullWidth
                        autoComplete="current-password"
                        type={showPassword ? 'text' : 'password'}
                        label="Password"
                        {...getFieldProps('password')}
                        InputProps={{
                            endAdornment: (
                                <InputAdornment position="end">
                                    <IconButton edge="end" onClick={() => setShowPassword((prev) => !prev)}>
                                        <Icon icon={showPassword ? eyeOutline : eyeOffOutline}/>
                                    </IconButton>
                                </InputAdornment>
                            ),
                            startAdornment: (
                                <InputAdornment position="start">
                                    <VpnKeyOutlinedIcon/>
                                </InputAdornment>
                            )
                        }}
                        error={Boolean(touched.password && errors.password)}
                        helperText={touched.password && errors.password}
                    />

                    <TextField
                        fullWidth
                        autoComplete="current-password"
                        type={showPasswordAgain ? 'text' : 'password'}
                        label="Confirm Password"
                        {...getFieldProps('passwordAgain')}
                        InputProps={{
                            endAdornment: (
                                <InputAdornment position="end">
                                    <IconButton edge="end" onClick={() => setShowPasswordAgain((prev) => !prev)}>
                                        <Icon icon={showPasswordAgain ? eyeOutline : eyeOffOutline}/>
                                    </IconButton>
                                </InputAdornment>
                            ),
                            startAdornment: (
                                <InputAdornment position="start">
                                    <VpnKeyOutlinedIcon/>
                                </InputAdornment>
                            )
                        }}
                        error={Boolean(touched.passwordAgain && errors.passwordAgain)}
                        helperText={touched.passwordAgain && errors.passwordAgain}
                    />

                    <LoadingButton
                        fullWidth
                        size="large"
                        type="submit"
                        variant="contained"
                        onClick={()=>
                            setIsLoading(true)}
                    >
                        {isLoading ? (
                            <>
                                <CircularProgress color="inherit" size={20}/>
                            </>
                        ) : null}
                        Sign Up!
                    </LoadingButton>
                </Stack>
            </Form>
        </FormikProvider>
    );
}

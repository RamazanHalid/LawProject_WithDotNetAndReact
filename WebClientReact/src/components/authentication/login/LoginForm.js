import * as Yup from 'yup';
import React, {useEffect, useState} from 'react';
import {Link as RouterLink, useNavigate} from 'react-router-dom';
import {useFormik, Form, FormikProvider} from 'formik';
import {Icon} from '@iconify/react';
import eyeOutline from '@iconify/icons-eva/eye-outline';
import eyeOffOutline from '@iconify/icons-eva/eye-off-outline';

// material
import PersonOutlineOutlinedIcon from '@mui/icons-material/PersonOutlineOutlined';
import VpnKeyOutlinedIcon from '@mui/icons-material/VpnKeyOutlined';
import {
    Link,
    Stack,
    Checkbox,
    TextField,
    IconButton,
    InputAdornment,
    FormControlLabel, Typography
} from '@mui/material';
import {LoadingButton} from '@mui/lab';
import PopupMessageService from '../../../services/popupMessage.service';
import AuthService from '../../../services/auth.service';
import {Global} from "../../../Global";
import CircularProgress from "@mui/material/CircularProgress";

// ----------------------------------------------------------------------

export default function LoginForm() {
    const navigate = useNavigate();
    const [showPassword, setShowPassword] = useState(false);
    const authService = new AuthService()
    const popupMessageService = new PopupMessageService();
    const catchMessagee = Global.catchMessage;
    const [isLoading, setIsLoading] = useState(false);

    const LoginSchema = Yup.object().shape({
        phone: Yup.string().required('phone is required'),
        password: Yup.string().required('Password is required')
    });

    const formik = useFormik({
        initialValues: {
            phone: '',
            password: ''
        },
        validationSchema: LoginSchema,
        onSubmit: () => {
            authService
                .login(formik.values.phone, formik.values.password)
                .then(
                    (response) => {
                        if (response.data.Success) {
                            localStorage.setItem('USER', JSON.stringify(response.data.Data));
                            // console.log(response.data.Data);
                            localStorage.setItem(
                                'usr',
                                JSON.stringify({
                                    cellPhone: formik.values.phone,
                                    password: formik.values.password
                                })
                            );
                            setIsLoading(false)
                            navigate('/licencesList/' + response.data.Data);
                        } else {
                            setIsLoading(false)
                            console.log(response.data.Message);
                            popupMessageService.AlertSuccessMessage(response.data.Message);
                        }
                    },
                    (error) => {
                        setIsLoading(false)
                        if (error.response.data.SituationCode === 3) {
                            navigate('/approveUser');
                        } else {
                            console.log(error.response.data);
                            popupMessageService.AlertErrorMessage(error.response.data.Message);
                        }
                    }
                )
                .catch((catchError) => {
                    setIsLoading(false)
                    console.log(catchError.data)
                    popupMessageService.AlertErrorMessage(catchMessagee)
                });
        }
    });
    const {errors, touched, values, handleSubmit, getFieldProps} = formik;

    const handleShowPassword = () => {
        setShowPassword((show) => !show);
    };
    useEffect(() => {
    });
    return (
        <FormikProvider value={formik}>
            <Form autoComplete="on" noValidate onSubmit={handleSubmit}>
                <Stack spacing={3}>
                    <TextField
                        fullWidth
                        type="phone"
                        label="Cell Phone"
                        placeholder="5xxxxxxxxx"
                        {...getFieldProps('phone')}
                        InputProps={{
                            startAdornment: (
                                <InputAdornment position="start">
                                    <PersonOutlineOutlinedIcon/>
                                </InputAdornment>
                            )
                        }}
                        error={Boolean(touched.phone && errors.phone)}
                        helperText={touched.phone && errors.phone}
                    />

                    <TextField
                        fullWidth
                        autoComplete="current-password"
                        type={showPassword ? 'text' : 'password'}
                        label="Password"
                        {...getFieldProps('password')}
                        InputProps={{
                            endAdornment: (
                                <InputAdornment position="end">
                                    <IconButton onClick={handleShowPassword} edge="end">
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
                </Stack>

                <Stack direction="row" alignItems="center" justifyContent="space-between" sx={{my: 2}}>
                    <Typography/>
                    <Link component={RouterLink} variant="subtitle2" to="/forgotPassword">
                        Forgot password?
                    </Link>
                </Stack>
                <LoadingButton
                    fullWidth
                    size="large"
                    type="submit"
                    variant="contained"
                    onClick={()=>
                        setIsLoading(true)
                }
                >
                    {isLoading ? (
                        <>
                            <CircularProgress color="inherit" size={20}/>
                        </>
                    ) : null}
                    Login
                </LoadingButton>
            </Form>
        </FormikProvider>
    );
}

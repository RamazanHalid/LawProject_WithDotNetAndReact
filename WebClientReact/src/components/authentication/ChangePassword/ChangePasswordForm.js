import * as Yup from 'yup';
import {useNavigate} from 'react-router-dom';
import {useFormik, Form, FormikProvider} from 'formik';
// material
import {Stack, TextField, InputAdornment, Button} from '@mui/material';
import PhoneOutlinedIcon from '@mui/icons-material/PhoneOutlined';
import TextsmsOutlinedIcon from '@mui/icons-material/TextsmsOutlined';
import AuthService from '../../../services/auth.service';
import PopupMessageService from '../../../services/popupMessage.service';
import React, {useState} from "react";
import CircularProgress from "@mui/material/CircularProgress";

// ----------------------------------------------------------------------

export default function ChangePasswordForm() {
    const navigate = useNavigate();
    const authService = new AuthService();
    const [isLoading, setIsLoading] = useState(false);

    const LoginSchema = Yup.object().shape({
        cellPhone: Yup.string().required('Cell phone is required'),
        smsCode: Yup.string().required('Messages code is required'),
        newPassword: Yup.string().required('New password is required')
    });

    const formik = useFormik({
        initialValues: {
            cellPhone: '',
            smsCode: '',
            newPassword: ''
        },
        validationSchema: LoginSchema,
        onSubmit: () => {
            const popupMessageService = new PopupMessageService();
            authService
                .UpdateUserPassword(
                    formik.values.cellPhone,
                    formik.values.smsCode,
                    formik.values.newPassword
                )
                .then((response) => {
                        setIsLoading(false)
                        popupMessageService.AlertSuccessMessage(response.data.Message);
                        console.log(response.data.Message);
                        navigate('/');
                    },
                    (error) => {
                        setIsLoading(false)
                        popupMessageService.AlertErrorMessage(error.response.data.Message);
                    })
                .catch((errorResponse) => {
                    setIsLoading(false)
                    popupMessageService.AlertErrorMessage(errorResponse.data.Message);
                });
        }
    });
    const {errors, touched, handleSubmit, getFieldProps} = formik;

    return (
        <FormikProvider value={formik}>
            <Form autoComplete="on" noValidate onSubmit={handleSubmit}>
                <Stack spacing={2.5}>
                    <TextField
                        fullWidth
                        type="phone"
                        label="Cell phone"
                        placeholder="5xxxxxxxxx"
                        {...getFieldProps('cellPhone')}
                        error={Boolean(touched.cellPhone && errors.cellPhone)}
                        helperText={touched.cellPhone && errors.cellPhone}
                        InputProps={{
                            startAdornment: (
                                <InputAdornment position="start">
                                    <PhoneOutlinedIcon/>
                                </InputAdornment>
                            )
                        }}
                    />
                    <TextField
                        fullWidth
                        type="number"
                        label="Messages Code"
                        {...getFieldProps('smsCode')}
                        InputProps={{
                            startAdornment: (
                                <InputAdornment position="start">
                                    <TextsmsOutlinedIcon/>
                                </InputAdornment>
                            )
                        }}
                        error={Boolean(touched.smsCode && errors.smsCode)}
                        helperText={touched.smsCode && errors.smsCode}
                    />
                    <TextField
                        fullWidth
                        label="New Password"
                        {...getFieldProps('newPassword')}
                        InputProps={{
                            startAdornment: (
                                <InputAdornment position="start">
                                    <TextsmsOutlinedIcon/>
                                </InputAdornment>
                            )
                        }}
                        error={Boolean(touched.newPassword && errors.newPassword)}
                        helperText={touched.newPassword && errors.newPassword}
                    />
                    <Button fullWidth size="large" type="submit" variant="contained"
                            onClick={() =>
                                setIsLoading(true)}
                    >
                        {isLoading ? (
                            <>
                                <CircularProgress color="inherit" size={20}/>
                            </>
                        ) : null}
                        Update Password!
                    </Button>
                </Stack>
            </Form>
        </FormikProvider>
    );
}

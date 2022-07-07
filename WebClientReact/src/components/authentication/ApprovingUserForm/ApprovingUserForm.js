import * as Yup from 'yup';
import {useNavigate} from 'react-router-dom';
import {useFormik, Form, FormikProvider} from 'formik';
// material
import {Stack, TextField, InputAdornment, Button} from '@mui/material';
import PhoneOutlinedIcon from '@mui/icons-material/PhoneOutlined';
import TextsmsOutlinedIcon from '@mui/icons-material/TextsmsOutlined';
import AuthService from '../../../services/auth.service';
import PopupMessageService from '../../../services/popupMessage.service';
import {Global} from "../../../Global";
import React, {useState} from "react";
import CircularProgress from "@mui/material/CircularProgress";

// ----------------------------------------------------------------------

export default function ApprovingUserForm() {
    const navigate = useNavigate();
    const catchMessagee = Global.catchMessage;
    const authService = new AuthService();
    const [isLoading, setIsLoading] = useState(false);

    const LoginSchema = Yup.object().shape({
        phoneConfirm: Yup.string().required('Cell phone is required'),
        SMSCode: Yup.string().required('Messages code is required')
    });

    const formik = useFormik({
        initialValues: {
            phoneConfirm: '',
            SMSCode: ''
        },
        validationSchema: LoginSchema,

        onSubmit: () => {
            const popupMessageService = new PopupMessageService();
            authService
                .approvingUser(formik.values.phoneConfirm, formik.values.SMSCode)
                .then((response) => {
                        console.log(response.data.Message);
                        setIsLoading(false)
                        navigate('/login');
                        popupMessageService.AlertSuccessMessage(response.data.Message);
                    },
                    (error) => {
                        setIsLoading(false)
                        popupMessageService.AlertErrorMessage(error.response.data.Message);
                    })
                .catch(() => {
                    setIsLoading(false)
                    popupMessageService.AlertErrorMessage(catchMessagee)
                });
        }
    });
    const {errors, touched, handleSubmit, getFieldProps} = formik;

    return (
        <FormikProvider value={formik}>
            <Form autoComplete="off" noValidate onSubmit={handleSubmit}>
                <Stack spacing={2.5}>
                    <TextField
                        fullWidth
                        type="phone"
                        label="Cell phone"
                        placeholder="5xxxxxxxxx"
                        {...getFieldProps('phoneConfirm')}
                        error={Boolean(touched.phoneConfirm && errors.phoneConfirm)}
                        helperText={touched.phoneConfirm && errors.phoneConfirm}
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
                        {...getFieldProps('SMSCode')}
                        InputProps={{
                            startAdornment: (
                                <InputAdornment position="start">
                                    <TextsmsOutlinedIcon/>
                                </InputAdornment>
                            )
                        }}
                        error={Boolean(touched.SMSCode && errors.SMSCode)}
                        helperText={touched.SMSCode && errors.SMSCode}
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
                        Confirm!
                    </Button>
                </Stack>
            </Form>
        </FormikProvider>
    );
}

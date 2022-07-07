// material
import {
    Box,
    Card,
    Container, IconButton, Paper,
    Stack, Table, TableBody, TableCell, TableContainer, TableHead, TablePagination, TableRow,
    Typography
} from '@mui/material';
// layouts
// components
import Page from '../components/Page';
import {Icon} from "@iconify/react";
import arrowBackOutline from "@iconify/icons-eva/arrow-back-outline";
import {useNavigate} from "react-router-dom";
import Scrollbar from "../components/Scrollbar";
import CircularProgress from "@mui/material/CircularProgress";
import React, {useEffect, useState} from "react";
import SmsHistoryService from "../services/smsHistory.service";
import PopupMessageService from "../services/popupMessage.service";
import {Global} from "../Global";
import {format} from "date-fns";
import ChevronLeftOutlinedIcon from "@mui/icons-material/ChevronLeftOutlined";
import ChevronRightOutlinedIcon from "@mui/icons-material/ChevronRightOutlined";
// ----------------------------------------------------------------------

export default function SentMessages() {
    const [isLoading, setIsLoading] = useState(true);
    const [allSentMessages, setAllSentMessages] = useState([]);
    const navigate = useNavigate();
    const smsHistoryService = new SmsHistoryService();
    const popupMessageService = new PopupMessageService();
    const catchMessagee = Global.catchMessage;
    const [pageNumber, setPageNumber] =useState(0);
    const [pageSize, setPageSize] = useState(3);

    const previousValues = () => {
        if (pageNumber > 0 && allSentMessages.length > 0) {
            getAllSentMessages(pageNumber - 1, pageSize)
            setPageNumber(pageNumber - 1)
        }
    }

    const nextValues = () => {
        if (allSentMessages.length >= 3) {
            getAllSentMessages(pageNumber + 1, pageSize)
            setPageNumber(pageNumber + 1)
        }
    }

    const getAllSentMessages = (pageNumber, pageSize) => {
        smsHistoryService.getAll(pageNumber, pageSize).then(
            (result) => {
                if (result.data.Success) {
                    setAllSentMessages(result.data.Data)
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

    useEffect(() => {
        getAllSentMessages(pageNumber,pageSize);
    }, [])

    return (
        <Page title="Sent Messages | MediLaw">
            <Container>
                <Stack direction="row" alignItems="center" justifyContent="flex-start" mb={4}>
                    <IconButton onClick={() => navigate(-1)} sx={{mr: 3, color: 'text.primary', bottom: 3}}
                                size="large">
                        <Icon icon={arrowBackOutline}/>
                    </IconButton>
                    <Typography variant="h4" gutterBottom>
                        Sent Messages
                    </Typography>
                </Stack>
                <Card sx={{marginTop: 8, maxWidth:900, marginLeft: 10}}>
                    <Paper sx={{ width: '100%', mb: 2 }}>
                    <Scrollbar>
                        {isLoading === true ?
                            <Stack sx={{color: 'grey.500', padding: 10}} spacing={2} direction="row"
                                   justifyContent='center'>
                                <CircularProgress color="inherit"/>
                            </Stack>
                            :
                            <>
                                {allSentMessages.length > 0 ? (
                                    <TableContainer component={Paper}>
                                        <Table sx={{minWidth: 650}} aria-label="simple table">
                                            <TableHead>
                                                <TableRow sx={{backgroundColor: '#f7f7f7'}}>
                                                    <TableCell sx={{paddingLeft: 7}}>Recipient Name</TableCell>
                                                    <TableCell align="left">Recipient Role</TableCell>
                                                    <TableCell align="left">Date</TableCell>
                                                    <TableCell align="left">Phone Number</TableCell>
                                                    <TableCell align="right"/>
                                                </TableRow>
                                            </TableHead>
                                            <TableBody>
                                                <>
                                                    {allSentMessages.map((row) => (
                                                        <TableRow
                                                            key={row.SmsHistoryId}
                                                            sx={{'&:last-child td, &:last-child th': {border: 0}}}
                                                        >
                                                            <TableCell component="th" scope="row" sx={{paddingLeft: 7}}>
                                                                {row.RecipientName}
                                                            </TableCell>
                                                            <TableCell component="th" scope="row">
                                                                {row.RecipientRole}
                                                            </TableCell>
                                                            <TableCell component="th" scope="row">
                                                                {format(new Date(row.Date), 'dd/MM/yyyy')}
                                                            </TableCell>
                                                            <TableCell component="th" scope="row">
                                                                {row.PhoneNumber}
                                                            </TableCell>
                                                            <TableCell align="right"/>
                                                        </TableRow>
                                                    ))}
                                                </>
                                            </TableBody>
                                        </Table>
                                        <Stack direction="row" alignItems="center" justifyContent="space-between" marginLeft={74}>
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
                                    <Stack>
                                        <img src="/static/illustrations/no.png" alt="login"/>
                                        <Typography variant="h3" gutterBottom textAlign='center' color='#a9a9a9'>No Data Found</Typography>
                                    </Stack>
                                )}
                            </>
                        }
                    </Scrollbar>
                    </Paper>
                </Card>
            </Container>
        </Page>
    );
}

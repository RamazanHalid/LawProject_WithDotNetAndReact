// material
import {styled} from '@mui/material/styles';
import {
    Box,
    Button,
    Card,
    CardContent,
    Container,
    IconButton,
    Paper,
    Stack, Table, TableCell,
    TableContainer, TableRow,
    Typography
} from '@mui/material';
// components
import Page from '../components/Page';
import React, {useEffect, useState} from "react";
import {useNavigate, useParams} from "react-router-dom";
import PopupMessageService from "../services/popupMessage.service";
import Fab from '@mui/material/Fab';
import {Global} from "../Global";
import CaseUpdateHistoryService from "../services/CaseUpdateHistory.service";
import ArrowBackIosOutlinedIcon from '@mui/icons-material/ArrowBackIosOutlined';
import ArrowForwardIosOutlinedIcon from '@mui/icons-material/ArrowForwardIosOutlined';
import {Icon} from "@iconify/react";
import arrowBackOutline from "@iconify/icons-eva/arrow-back-outline";
import {format} from "date-fns";
import Label from "../components/Label";
import CircularProgress from "@mui/material/CircularProgress";
// ----------------------------------------------------------------------

const RootStyle = styled(Page)(({theme}) => ({
    [theme.breakpoints.up('md')]: {
        display: 'flex'
    }
}));

// ----------------------------------------------------------------------

export default function CaseUpdateHistory() {
    const {id} = useParams()
    const popupMessageService = new PopupMessageService();
    const caseUpdateHistoryService = new CaseUpdateHistoryService();
    const catchMessagee = Global.catchMessage;
    const [caseUpdateHistory, setCaseUpdateHistory] = useState([])
    const [takeVal, setTakeVal] = useState(3)
    const [skipVal, setSkipVal] = useState(0)
    const [isLoading, setIsLoading] = useState(true);
    const navigate = useNavigate();

    const getAllCaseUpdateHistory = (skipVal, takeVal, caseId) => {
        caseUpdateHistoryService.getAllByCaseId(skipVal, takeVal, caseId).then(
            (result) => {
                if (result.data.Success) {
                    setCaseUpdateHistory(result.data.Data)
                    console.log(result.data.Data)
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
        if (skipVal > 0 && caseUpdateHistory.length > 0) {
            getAllCaseUpdateHistory(skipVal - 1, takeVal, id)
            setSkipVal(skipVal - 1)
        }
    }

    const nextValues = () => {
        if (caseUpdateHistory.length >= 3) {
            getAllCaseUpdateHistory(skipVal + 1, takeVal, id)
            setSkipVal(skipVal + 1)
        }
    }

    useEffect(() => {
        getAllCaseUpdateHistory(skipVal, takeVal, id)
    }, [])
    return (
        <RootStyle title="History | MediLaw">
            <Container>
                <Stack direction="row" alignItems="center" justifyContent="flex-start" mb={4}>
                    <IconButton onClick={() => navigate(-1)} sx={{mr: 3, color: 'text.primary', bottom: 3}}
                                size="large">
                        <Icon icon={arrowBackOutline}/>
                    </IconButton>
                    <Typography variant="h4" gutterBottom>History</Typography>
                    <Stack direction="row" alignItems="center" justifyContent="space-between" marginLeft={95}>
                        <Box sx={{display: 'flex', alignItems: 'center'}}>
                            <Box sx={{m: 0, position: 'relative'}}>
                                <Fab size="large" type="submit" variant="contained" onClick={previousValues}
                                     color={'primary'}>
                                    <ArrowBackIosOutlinedIcon/>
                                </Fab>
                            </Box>
                            <Box sx={{m: 0, position: 'relative', marginLeft: 3}}>
                                <Fab size="large" type="submit" variant="contained" onClick={nextValues}
                                     color={'primary'}>
                                    <ArrowForwardIosOutlinedIcon/>
                                </Fab>
                            </Box>
                        </Box>
                    </Stack>
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
                            {caseUpdateHistory.length > 0 ?
                                <>
                                    {caseUpdateHistory.map((row) =>
                                        <Card sx={{
                                            maxWidth: 330,
                                            minWidth: 330,
                                            marginTop: 5,
                                            marginRight: 1,
                                            marginLeft: 2
                                        }}>
                                            <CardContent>
                                                <Box sx={{minWidth: 300, marginLeft: -1}}>
                                                    <TableContainer component={Paper} sx={{}}>
                                                        <Table aria-label="simple table">
                                                            <TableRow key={row.CasesUpdateHistoryId} sx={{
                                                                backgroundColor: '#f7f7f7',
                                                                padding: 10,
                                                                border: '6px solid #fff',
                                                            }}>
                                                                <TableCell variant="head">Title</TableCell>
                                                                {row.DoesInfoChange === true ?
                                                                    <TableCell component="th" scope="row">
                                                                        <Label variant="ghost" color="warning"
                                                                               sx={{fontSize: 13}}>{row.Info}</Label>
                                                                    </TableCell>
                                                                    :
                                                                    <TableCell component="th" scope="row">
                                                                             {row.Info}
                                                                    </TableCell>
                                                                }
                                                            </TableRow>
                                                            <TableRow sx={{
                                                                backgroundColor: '#f7f7f7',
                                                                padding: 15,
                                                                border: '6px solid #fff'
                                                            }}>
                                                                <TableCell variant="head">Start Date</TableCell>
                                                                {row.DoesItStartDateChange === true ?
                                                                    <TableCell component="th" scope="row">
                                                                        <Label variant="ghost" color="warning"
                                                                               sx={{fontSize: 13}}>
                                                                            {format(new Date(row.StartDate), 'dd/MM/yyyy')}
                                                                        </Label>
                                                                    </TableCell>
                                                                    :
                                                                    <TableCell component="th" scope="row">
                                                                            {format(new Date(row.StartDate), 'dd/MM/yyyy')}
                                                                    </TableCell>
                                                                }
                                                            </TableRow>
                                                            <TableRow sx={{
                                                                backgroundColor: '#f7f7f7',
                                                                padding: 15,
                                                                border: '6px solid #fff'
                                                            }}>
                                                                <TableCell variant="head">Decision Date</TableCell>
                                                                {row.DoesItDecisionDateChange === true ?
                                                                    <TableCell component="th" scope="row">
                                                                        <Label variant="ghost" color="warning"
                                                                               sx={{fontSize: 13}}>
                                                                            {format(new Date(row.DecisionDate), 'dd/MM/yyyy')}</Label>
                                                                    </TableCell>
                                                                    :
                                                                    <TableCell component="th" scope="row">
                                                                            {format(new Date(row.DecisionDate), 'dd/MM/yyyy')}
                                                                    </TableCell>
                                                                }
                                                            </TableRow>
                                                            <TableRow sx={{
                                                                backgroundColor: '#f7f7f7',
                                                                padding: 15,
                                                                border: '6px solid #fff'
                                                            }}>
                                                                <TableCell variant="head">End Date</TableCell>
                                                                {row.DoesItEndDateChange === true ?
                                                                    <TableCell component="th" scope="row">
                                                                        <Label variant="ghost" color="warning"
                                                                               sx={{fontSize: 13}}>
                                                                            {format(new Date(row.EndDate), 'dd/MM/yyyy')}</Label>
                                                                    </TableCell>
                                                                    :
                                                                    <TableCell component="th" scope="row">
                                                                            {format(new Date(row.EndDate), 'dd/MM/yyyy')}
                                                                    </TableCell>
                                                                }
                                                            </TableRow>
                                                            <TableRow sx={{
                                                                backgroundColor: '#f7f7f7',
                                                                padding: 10,
                                                                border: '6px solid #fff',
                                                            }}>
                                                                <TableCell variant="head">Customer</TableCell>
                                                                {row.DoesCustomerChange === true ?
                                                                    <TableCell component="th" scope="row">
                                                                        <Label variant="ghost" color="warning"
                                                                               sx={{fontSize: 13}}>{row.Customer.CustomerName}</Label>
                                                                    </TableCell>
                                                                    :
                                                                    <TableCell component="th" scope="row">
                                                                        {row.Customer.CustomerName}
                                                                    </TableCell>
                                                                }
                                                            </TableRow>
                                                            <TableRow sx={{
                                                                backgroundColor: '#f7f7f7',
                                                                padding: 10,
                                                                border: '6px solid #fff',
                                                            }}>
                                                                <TableCell variant="head">Court Office</TableCell>
                                                                {row.DoesCourtOfficeChange === true ?
                                                                    <TableCell component="th" scope="row">
                                                                        <Label variant="ghost" color="warning"
                                                                               sx={{fontSize: 13}}>{row.CourtOffice.CourtOfficeName}</Label>
                                                                    </TableCell>
                                                                    :
                                                                    <TableCell component="th" scope="row">
                                                                               {row.CourtOffice.CourtOfficeName}
                                                                    </TableCell>
                                                                }
                                                            </TableRow>
                                                            <TableRow sx={{
                                                                backgroundColor: '#f7f7f7',
                                                                padding: 10,
                                                                border: '6px solid #fff',
                                                            }}>
                                                                <TableCell variant="head">Court Office Type</TableCell>
                                                                {row.DoesCourtOfficeTypeChange === true ?
                                                                    <TableCell component="th" scope="row">
                                                                        <Label variant="ghost" color="warning"
                                                                               sx={{fontSize: 13}}>{row.CourtOfficeType.CourtOfficeTypeName}</Label>
                                                                    </TableCell>
                                                                    :
                                                                    <TableCell component="th" scope="row">
                                                                            {row.CourtOfficeType.CourtOfficeTypeName}
                                                                    </TableCell>
                                                                }
                                                            </TableRow>
                                                            <TableRow sx={{
                                                                backgroundColor: '#f7f7f7',
                                                                padding: 10,
                                                                border: '6px solid #fff',
                                                            }}>
                                                                <TableCell variant="head">Case Type</TableCell>
                                                                {row.DoesCaseTypeChange === true ?
                                                                    <TableCell component="th" scope="row">
                                                                        <Label variant="ghost" color="warning"
                                                                               sx={{fontSize: 13}}>{row.CaseType.Description}</Label>
                                                                    </TableCell>
                                                                    :
                                                                    <TableCell component="th" scope="row">
                                                                      {row.CaseType.Description}
                                                                    </TableCell>
                                                                }
                                                            </TableRow>
                                                            <TableRow sx={{
                                                                backgroundColor: '#f7f7f7',
                                                                padding: 10,
                                                                border: '6px solid #fff',
                                                            }}>
                                                                <TableCell variant="head">Case No</TableCell>
                                                                {row.DoesCaseNoChange === true ?
                                                                    <TableCell component="th" scope="row">
                                                                        <Label variant="ghost" color="warning"
                                                                               sx={{fontSize: 13}}>{row.CaseNo}</Label>
                                                                    </TableCell>
                                                                    :
                                                                    <TableCell component="th" scope="row">
                                                                               {row.CaseNo}
                                                                    </TableCell>
                                                                }
                                                            </TableRow>
                                                        </Table>
                                                    </TableContainer>
                                                </Box>
                                            </CardContent>
                                        </Card>
                                    )}
                                </>
                                : null}
                        </>
                    }
                </Stack>
            </Container>
        </RootStyle>
    );
}

// material
import {
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
import {useNavigate, useParams} from "react-router-dom";
import Scrollbar from "../components/Scrollbar";
import CircularProgress from "@mui/material/CircularProgress";
import {useEffect, useState} from "react";
import SmsHistoryService from "../services/smsHistory.service";
import PopupMessageService from "../services/popupMessage.service";
import {Global} from "../Global";
import {format} from "date-fns";
// ----------------------------------------------------------------------

export default function AdminSmsHistory() {
    const [isLoading, setIsLoading] = useState(true);
    const [smsHistory, setSmsHistory] = useState([]);
    const navigate = useNavigate();
    const smsHistoryService = new SmsHistoryService();
    const popupMessageService = new PopupMessageService();
    const catchMessagee = Global.catchMessage;
    const [pageNumber, setPageNumber] =useState(0);
    const [pageSize, setPageSize] = useState(3);
    const [count, setCount] = useState(10);
    const {id} = useParams()

    const handleChangePage = (event, newPage) => {
        console.log("newPageNumber : ",newPage)
        getAllSmsHistories(newPage,pageSize, id)
        setPageNumber(newPage);
    };

    const handleChangeRowsPerPage = (event) => {
        setPageSize(event.target.value);
        setPageNumber(1);
        getAllSmsHistories(1, event.target.value,id)
    };

    const getAllSmsHistories = (pageNumber, pageSize,licenceId) => {
        smsHistoryService.getAllAsAdmin(pageNumber, pageSize,licenceId).then(
            (result) => {
                if (result.data.Success) {
                    setSmsHistory(result.data.Data)
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
        getAllSmsHistories(pageNumber,pageSize, id);
    }, [])

    return (
        <Page title="SMS History | MediLaw">
            <Container>
                <Stack direction="row" alignItems="center" justifyContent="flex-start" mb={4}>
                    <IconButton onClick={() => navigate(-1)} sx={{mr: 3, color: 'text.primary', bottom: 3}}
                                size="large">
                        <Icon icon={arrowBackOutline}/>
                    </IconButton>
                    <Typography variant="h4" gutterBottom>
                        SMS History
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
                                    {smsHistory.length > 0 ? (
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
                                                        {smsHistory.map((row) => (
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
                                                            </TableRow>
                                                        ))}
                                                    </>
                                                </TableBody>
                                            </Table>
                                            <TablePagination
                                                rowsPerPageOptions={[5, 10, 25]}
                                                component="div"
                                                count={count}
                                                page={pageNumber}
                                                onPageChange={handleChangePage}
                                                rowsPerPage={pageSize}
                                                onRowsPerPageChange={handleChangeRowsPerPage}
                                            />
                                        </TableContainer>
                                    ) : (
                                        <TableCell sx={{width: '40%'}}>
                                            <img src="/static/illustrations/no.png" alt="login"/>
                                            <Typography variant="h3" gutterBottom textAlign='center' color='#a9a9a9'>No Data Found</Typography>
                                        </TableCell>
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

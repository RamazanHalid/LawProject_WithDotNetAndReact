// material
import {styled} from '@mui/material/styles';
import {
    Box,
    Button, Card,
    Container,
    IconButton, InputAdornment, Link,
    Paper,
    Stack,
    Table, TableBody, TableCell,
    TableContainer,
    TableHead, TableRow, TextField,
    Typography
} from '@mui/material';
// layouts
// components
import Page from '../components/Page';
import {Icon} from "@iconify/react";
import arrowBackOutline from "@iconify/icons-eva/arrow-back-outline";
import {Link as RouterLink, useNavigate, useParams} from "react-router-dom";
import plusFill from "@iconify/icons-eva/plus-fill";
import React, {useEffect, useState} from "react";
import CloseIcon from "@material-ui/icons/Close";
import Modal from "@mui/material/Modal";
import Scrollbar from "../components/Scrollbar";
import CircularProgress from "@mui/material/CircularProgress";
import PopupMessageService from "../services/popupMessage.service";
import {Global} from "../Global";
import CaseDocumentsService from "../services/CaseDocuments.service";
import SubtitlesOutlinedIcon from "@mui/icons-material/SubtitlesOutlined";
import LoupeOutlinedIcon from '@mui/icons-material/LoupeOutlined';
import FilesHelperService from "../services/FilesHelper.setvice";
import InsertLinkOutlinedIcon from '@mui/icons-material/InsertLinkOutlined';
import roundUpdate from "@iconify/icons-ic/round-update";
import outlineCloudDownload from '@iconify/icons-ic/outline-cloud-download';
// ----------------------------------------------------------------------

const RootStyle = styled(Page)(({theme}) => ({
    [theme.breakpoints.up('md')]: {
        display: 'flex'
    }
}));
const AccountStyle = styled('div')(({theme}) => ({
    display: 'flex',
    alignItems: 'center',
    padding: theme.spacing(2, 2.5),
    borderRadius: theme.shape.borderRadius,
}));
// ----------------------------------------------------------------------

export default function Attachment() {
    const [openModal, setOpenModal] = useState(false);
    const [attachments, setAttachments] = useState([]);
    const [caseDocumentId, setCaseDocumentId] = useState(0);
    const [filePath, setFilePath] = useState("");
    const [title, setTitle] = useState("");
    const [details, setDetails] = useState("");
    const [isLoading, setIsLoading] = useState(true);
    const [loader, setLoader] = useState(false);
    const navigate = useNavigate();
    const popupMessageService = new PopupMessageService();
    const filesHelperService = new FilesHelperService();
    const caseDocumentsService = new CaseDocumentsService();
    const catchMessagee = Global.catchMessage;
    const {id} = useParams()

    const handleOpen = () => {
        setTitle("")
        setDetails("")
        setCaseDocumentId(0)
        setOpenModal(true)
    };
    const handleClose = () => {
        setOpenModal(false)
    }

    const uploadFile = (event) => {
        const myFile = event.target.files[0];
        filesHelperService.addFileForCaseDocuments(myFile).then(
            (result) => {
                if (result.data.Success) {
                    setLoader(false)
                    console.log(result.data)
                    setFilePath(result.data.Data)
                }
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    }

    const getAllDocuments = (id) => {
        caseDocumentsService.getAll(id).then(
            (result) => {
                if (result.data.Success) {
                    setAttachments(result.data.Data)
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


    function addNewRecord() {
        let obj = {
            title: title,
            details: details,
            documentPath: filePath,
            caseeId: id
        }
        let re = caseDocumentsService.add(obj)
        re.then((result) => {
                if (result.data.Success) {
                    getAllDocuments()
                    setOpenModal(false)
                    popupMessageService.AlertSuccessMessage(result.data.Message)
                }
            },
            (error) => {
                setOpenModal(false)
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    }

    useEffect(() => {
        getAllDocuments()
    }, []);


    return (
        <RootStyle title="Attachments | MediLaw">
            <Container>
                <Stack direction="row" alignItems="center" justifyContent="flex-start" mb={4}>
                    <IconButton onClick={() => navigate(-1)} sx={{mr: 3, color: 'text.primary', bottom: 3}}
                                size="large">
                        <Icon icon={arrowBackOutline}/>
                    </IconButton>
                    <Typography variant="h4" gutterBottom>
                        Attachments
                    </Typography>
                    <Stack direction="row" alignItems="center" justifyContent="space-between" marginLeft={87}>
                        <Button onClick={handleOpen} variant="contained" startIcon={<Icon icon={plusFill}/>}>
                            New Record
                        </Button>
                    </Stack>

                    <Modal sx={{backgroundColor: "rgba(0, 0, 0, 0.5)"}}
                           hideBackdrop={true}
                           disableEscapeKeyDown={true}
                           open={openModal}
                           aria-labelledby="modal-modal-title"
                           aria-describedby="modal-modal-description"
                    >
                        <Box sx={{
                            position: 'absolute',
                            top: '50%',
                            left: '50%',
                            transform: 'translate(-50%, -50%)',
                            width: 470,
                            backgroundColor: 'background.paper',
                            border: '2px solid #fff',
                            boxShadow: 24,
                            p: 4,
                            borderRadius: 2
                        }}>
                            <Stack mb={5} flexDirection="row" justifyContent='space-between'>
                                <Typography id="modal-modal-title" variant="h6" component="h2">
                                    Add new record!
                                </Typography>
                                <IconButton sx={{bottom: 4}}>
                                    <CloseIcon onClick={handleClose}/>
                                </IconButton>
                            </Stack>
                            <Stack spacing={2}>
                                <Stack mb={3} alignItems="center" justifyContent="space-around">
                                    <Stack mb={0} spacing={3}>
                                        <TextField
                                            fullWidth
                                            type='text'
                                            size='small'
                                            label="Title"
                                            value={title}
                                            onChange={(e) => setTitle(e.target.value)}
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
                                            size='small'
                                            label="Details"
                                            value={details}
                                            onChange={(e) => setDetails(e.target.value)}
                                            InputProps={{
                                                startAdornment: (
                                                    <InputAdornment position="start">
                                                        <LoupeOutlinedIcon/>
                                                    </InputAdornment>
                                                )
                                            }}
                                        />
                                        {loader ? (
                                            <>
                                                <CircularProgress color="inherit" size={20}/>
                                            </>
                                        ) : null}
                                        <TextField
                                            type="file"
                                            fullWidth
                                            size='small'
                                            label="File"
                                            onClick={(event) => {
                                                setLoader(true)
                                                uploadFile(event)
                                            }}
                                            key={Math.random().toString(36).substr(2, 9)}
                                            InputProps={{
                                                startAdornment: (
                                                    <InputAdornment position="start">
                                                        <InsertLinkOutlinedIcon/>
                                                    </InputAdornment>
                                                )
                                            }}
                                        >
                                        </TextField>

                                    </Stack>
                                </Stack>
                                <Button sx={{bottom: 7}} size="large" type="submit"
                                        variant="contained"
                                        onClick={() => addNewRecord()}>
                                    Add!
                                </Button>
                            </Stack>
                        </Box>
                    </Modal>
                </Stack>
                <Card sx={{marginTop: 10, maxWidth: 900, marginLeft: 10}}>
                    <Scrollbar>
                        {isLoading === true ?
                            <Stack sx={{color: 'grey.500', padding: 10}} spacing={2} direction="row"
                                   justifyContent='center'>
                                <CircularProgress color="inherit"/>
                            </Stack>
                            :
                            <>
                                {attachments.length > 0 ? (
                                    <TableContainer component={Paper}>
                                        <Table sx={{minWidth: 650}} aria-label="simple table">
                                            <TableHead>
                                                <TableRow sx={{backgroundColor: '#f7f7f7'}}>
                                                    <TableCell sx={{paddingLeft: 7}}>Title</TableCell>
                                                    <TableCell align="left">Details</TableCell>
                                                    <TableCell align="left">Creator Name</TableCell>
                                                    <TableCell align="left">Creator Cellphone</TableCell>
                                                    <TableCell align="left">Download</TableCell>
                                                    <TableCell align="right"/>
                                                </TableRow>
                                            </TableHead>
                                            <TableBody>
                                                <>
                                                    {attachments.map((row) => (
                                                        <TableRow
                                                            key={row.CaseDocumentId}
                                                            sx={{'&:last-child td, &:last-child th': {border: 0}}}
                                                        >
                                                            <TableCell component="th" scope="row"
                                                                       sx={{paddingLeft: 7}}>
                                                                {row.Title}
                                                            </TableCell>
                                                            <TableCell component="th" scope="row">
                                                                {row.Details}
                                                            </TableCell>
                                                            <TableCell component="th" scope="row">
                                                                {row.Creator.FirstName} {row.Creator.LastName}
                                                            </TableCell>
                                                            <TableCell component="th" scope="row">
                                                                {row.Creator.CellPhone}
                                                            </TableCell>
                                                            <TableCell sx={{maxWidth:110}}>
                                                                <Link style={{textDecoration: 'none', color: 'grey'}}
                                                                      href={'https://webapi.emlakofisimden.com' + row.DocumentPath}>
                                                                    <AccountStyle sx={{
                                                                        p: 1.6,
                                                                        border: '1px dashed #b1b9be',
                                                                        '&:hover': {
                                                                            backgroundColor: '#F4F6F8',
                                                                            boxShadow: 'none',
                                                                        }
                                                                    }}>
                                                                        <Icon icon={outlineCloudDownload} width={20} height={20}/>
                                                                        <Box sx={{ml: 1}}>
                                                                            <Typography variant="subtitle2"
                                                                                        sx={{color: 'text.primary'}}>
                                                                                Download
                                                                            </Typography>
                                                                        </Box>
                                                                    </AccountStyle>
                                                                </Link>
                                                            </TableCell>
                                                        </TableRow>
                                                    ))}
                                                </>
                                            </TableBody>
                                        </Table>
                                    </TableContainer>
                                ) : (
                                    <TableCell sx={{width: '40%'}}>
                                        <img src="/static/illustrations/no.png" alt="login"/>
                                        <Typography variant="h3" gutterBottom textAlign='center' color='#a9a9a9'>No Data
                                            Found</Typography>
                                    </TableCell>
                                )}
                            </>
                        }
                    </Scrollbar>
                </Card>
            </Container>
        </RootStyle>
    );
}

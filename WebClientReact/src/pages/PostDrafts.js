// material
import {
    Box, Button, Card, CardActions, CardContent, Checkbox,
    Container, Divider, Grid, IconButton, InputAdornment, Paper,
    Stack, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, TextField,
    Typography
} from '@mui/material';
// layouts
// components
import Page from '../components/Page';
import {Icon} from "@iconify/react";
import arrowBackOutline from "@iconify/icons-eva/arrow-back-outline";
import {useNavigate} from "react-router-dom";
import {Global} from "../Global";
import PopupMessageService from "../services/popupMessage.service";
import SmsTemplateService from "../services/smsTemplate.service";
import React, {useEffect, useState} from "react";
import CircularProgress from "@mui/material/CircularProgress";
import roundUpdate from "@iconify/icons-ic/round-update";
import plusFill from "@iconify/icons-eva/plus-fill";
import CloseIcon from "@material-ui/icons/Close";
import Modal from "@mui/material/Modal";
import trash2Outline from "@iconify/icons-eva/trash-2-outline";
import SubtitlesOutlinedIcon from '@mui/icons-material/SubtitlesOutlined';
import ChatBubbleOutlineOutlinedIcon from '@mui/icons-material/ChatBubbleOutlineOutlined';
// ----------------------------------------------------------------------

export default function PostDrafts() {
    const navigate = useNavigate();
    const [isLoading, setIsLoading] = useState(true);
    const [allSmsTemplate, setAllSmsTemplate] = useState([]);
    const [smsTitle, setSmsTitle] = useState("");
    const [smsMessage, setSmsMessage] = useState("");
    const [postDraftId, setPostDraftId] = useState(0);
    const [openModal, setOpenModal] = useState(false);

    const catchMessagee = Global.catchMessage;
    const smsTemplateService = new SmsTemplateService();
    const popupMessageService = new PopupMessageService();

    const getAllSmsTemplate = () => {
        smsTemplateService.getAll().then(
            (result) => {
                if (result.data.Success) {
                    setAllSmsTemplate(result.data.Data);
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

    function deletePostDraft(id) {
        smsTemplateService.delete(id).then(result => {
                if (result.data.Success) {
                    getAllSmsTemplate()
                    popupMessageService.AlertSuccessMessage(result.data.Message);
                }
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    };

    function modalForEdit(id) {
        smsTemplateService.getById(id).then(result => {
            if (result.data.Success) {
                let smsTemplate = result.data.Data
                setPostDraftId(smsTemplate.SmsTemplateId)
                setSmsTitle(smsTemplate.SmsHeader)
                setSmsMessage(smsTemplate.Message)
            }
        })
        setOpenModal(true)
    }

    function addNewRecord() {
        let obj = {
            smsTemplateId: postDraftId,
            smsHeader: smsTitle,
            message: smsMessage
        }
        let re
        if (postDraftId > 0) {
            obj.EventtId = postDraftId
            re = smsTemplateService.update(obj)
        } else {
            re = smsTemplateService.add(obj)
        }
        re.then((result) => {
                if (result.data.Success) {
                    getAllSmsTemplate()
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

    const handleOpen = () => {
        setPostDraftId(0)
        setSmsTitle("")
        setSmsMessage("")
        setOpenModal(true)
    };
    const handleClose = () => {
        setOpenModal(false)
    };

    useEffect(() => {
        getAllSmsTemplate();
    }, []);

    return (
        <Page title="Post Drafts | MediLaw">
            <Container>
                <Stack direction="row" alignItems="center" justifyContent="flex-start" mb={4}>
                    <IconButton onClick={() => navigate(-1)} sx={{ mr: 3, color: 'text.primary', bottom:3 }} size="large">
                        <Icon icon={arrowBackOutline} />
                    </IconButton>
                    <Typography variant="h4" gutterBottom>
                        Post Drafts
                    </Typography>
                    <Stack direction="row" alignItems="center" justifyContent="space-between" marginLeft={87}>
                        <Button onClick={handleOpen} variant="contained" startIcon={<Icon icon={plusFill}/>}>
                            New Record
                        </Button>
                    </Stack>
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
                            p: 4,
                            borderRadius: 2
                        }}>
                            <Stack mb={5} flexDirection="row" justifyContent='space-between'>
                                {postDraftId > 0 ?
                                    <Typography id="modal-modal-title" variant="h6" component="h2">
                                        Edit record!
                                    </Typography>
                                    :
                                    <Typography id="modal-modal-title" variant="h6" component="h2">
                                        Add new record!
                                    </Typography>
                                }
                                <IconButton sx={{bottom: 4}}>
                                    <CloseIcon onClick={handleClose}/>
                                </IconButton>
                            </Stack>
                            <Stack spacing={3.5} mb={2}>
                                <TextField
                                        autoFocus
                                        size='small'
                                        label="Title"
                                        fullWidth
                                        value={smsTitle}
                                        onChange={(e) => setSmsTitle(e.target.value)}
                                        InputProps={{
                                            startAdornment: (
                                                <InputAdornment position="start">
                                                    <SubtitlesOutlinedIcon />
                                                </InputAdornment>
                                            )
                                        }}
                                    />
                                <TextField
                                        size='small'
                                        label="Message"
                                        fullWidth
                                        multiline
                                        value={smsMessage}
                                        onChange={(e) => setSmsMessage(e.target.value)}
                                        InputProps={{
                                            startAdornment: (
                                                <InputAdornment position="start">
                                                    <ChatBubbleOutlineOutlinedIcon />
                                                </InputAdornment>
                                            )
                                        }}
                                    />
                                {postDraftId > 0 ?
                                    <Button size="large" type="submit" variant="contained"
                                            onClick={() => addNewRecord()}>Edit!</Button>
                                    :
                                    <Button size="large" type="submit" variant="contained"
                                            onClick={() => addNewRecord()}>Add!</Button>
                                }
                                </Stack>
                        </Box>
                    </Modal>
                <Grid container sx={{flexDirection: 'row', paddingLeft: 7, top: 10}}>
                    {isLoading === true ?
                        <Stack sx={{color: 'grey.500', paddingLeft: 53, paddingTop: 25}} spacing={2} direction="row"
                               justifyContent='center'>
                            <CircularProgress color="inherit"/>
                        </Stack>
                        :
                        <>
                            {allSmsTemplate.length > 0 ? (
                                <>
                                    {allSmsTemplate.map((row) => (
                                        <Card sx={{
                                            //maxWidth: 250,
                                            minWidth: 250,
                                            marginTop: 5,
                                            marginRight: 5,
                                        }}>
                                            <CardContent>
                                                <Typography sx={{p: 2, border: '1px dashed #b1b9be',marginTop: 0.5, borderRadius:1.5}} gutterBottom variant="h6"
                                                            component="div" key={row.SmsTemplateId}>
                                                    {row.SmsHeader}
                                                </Typography>
                                                <Stack sx={{paddingTop:1, paddingLeft:1}}>
                                                <Typography>
                                                    {row.Message}
                                                </Typography>
                                                </Stack>
                                                <CardActions sx={{paddingTop: 3}}>
                                                    <Button
                                                        onClick={() => modalForEdit(row.SmsTemplateId)}
                                                        sx={{backgroundColor: '#b1b9be'}}
                                                        variant="contained"
                                                        startIcon={<Icon icon={roundUpdate}/>}
                                                    >
                                                        Edit
                                                    </Button>
                                                        <Button
                                                            variant="contained"
                                                            onClick={()=> deletePostDraft(row.SmsTemplateId)}
                                                            sx={{backgroundColor: '#c9505c'}}
                                                            startIcon={<Icon icon={trash2Outline}/>}
                                                        >
                                                            Delete
                                                        </Button>
                                                </CardActions>
                                            </CardContent>
                                        </Card>
                                    ))}
                                </>
                            ) : (
                                <Stack>
                                    <img src="/static/illustrations/no.png" alt="login"/>
                                    <Typography variant="h3" gutterBottom textAlign='center'
                                                color='#a9a9a9'>No Data Found</Typography>
                                </Stack>
                            )}
                        </>
                    }
                </Grid>
            </Container>
        </Page>
    );
}

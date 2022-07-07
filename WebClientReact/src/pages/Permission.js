// material
import {
    Button, Card, CardContent, Checkbox,
    Container, Divider, Grid, IconButton,
    Stack,
    TableCell,
    Typography
} from '@mui/material';
// layouts
// components
import Page from '../components/Page';
import {useEffect, useState} from "react";
import PopupMessageService from "../services/popupMessage.service";
import {Global} from "../Global";
import OperationClaimGroupsService from "../services/operationClaimGroups.service";
import CircularProgress from "@mui/material/CircularProgress";
import ClaimsOperationsService from "../services/claimsOperations.service";
import {useNavigate, useParams} from "react-router-dom";
import {Icon} from "@iconify/react";
import saveOutline from '@iconify/icons-eva/save-outline';
import arrowBackOutline from "@iconify/icons-eva/arrow-back-outline";
// ----------------------------------------------------------------------

export default function Permission() {
    const [operationClaimsByGroup, setOperationClaimsByGroup] = useState([]);
    const [userClaimsOperations, setUserClaimsOperations] = useState([]);
    const [isLoading, setIsLoading] = useState(true);
    const popupMessageService = new PopupMessageService();
    const claimsOperationsService = new ClaimsOperationsService();
    const operationClaimGroupsService = new OperationClaimGroupsService();
    const catchMessagee = Global.catchMessage;
    const {id} = useParams()
    const navigate = useNavigate();

    const getAllUserLists = () => {
        operationClaimGroupsService
            .getAll()
            .then(
                (response) => {
                    setOperationClaimsByGroup(response.data.Data);
                    setIsLoading(false)
                },
                (error) => {
                    popupMessageService.AlertErrorMessage(error.response.data.Message);
                }
            )
            .catch(() => {
                popupMessageService.AlertErrorMessage(catchMessagee)
            });
    }

    const getAllOperationClaims = () => {
        claimsOperationsService
            .getAll(id)
            .then(
                (response) => {
                    setUserClaimsOperations(response.data.Data);
                    console.log(response.data.Data)
                    setIsLoading(false)
                },
                (error) => {
                    popupMessageService.AlertErrorMessage(error.response.data.Message);
                }
            )
            .catch(() => {
                popupMessageService.AlertErrorMessage(catchMessagee)
            });
    }

    const handleSelectedClaimsId = (e) => {
        let newList = [...userClaimsOperations]
        if (e.target.checked) {
            newList.push(parseInt(e.target.value))
            setUserClaimsOperations(newList)
            console.log('if checked true:', newList)
        } else {
            const index = newList.indexOf(parseInt(e.target.value));
            if (index > -1) {
                newList.splice(index, 1);
            }
            setUserClaimsOperations(newList)
            console.log('if checked false:', newList)
        }
    }

    const savingChanges = () => {
        claimsOperationsService
            .change(id, userClaimsOperations)
            .then(
                (response) => {
                    getAllOperationClaims()
                    popupMessageService.AlertSuccessMessage('The operation was successful');
                },
                (error) => {
                    popupMessageService.AlertErrorMessage(error.response.data.Message);
                }
            )
            .catch(() => {
                popupMessageService.AlertErrorMessage(catchMessagee)
            });
    }

    useEffect(() => {
        getAllOperationClaims();
        getAllUserLists();
    }, []);

    return (
        <Page title="Permissions | MediLaw">
            <Container>
                <Stack direction="row" alignItems="center" justifyContent="flex-start" mb={4}>
                    <IconButton onClick={() => navigate(-1)} sx={{ mr: 3, color: 'text.primary', bottom:3 }} size="large">
                        <Icon icon={arrowBackOutline} />
                    </IconButton>
                    <Typography variant="h4" gutterBottom>
                        Permissions
                    </Typography>
                <Stack direction="row" alignItems="center" justifyContent="space-between" marginLeft={87}>
                    <Button onClick={savingChanges} variant="contained" startIcon={<Icon icon={saveOutline}/>}>
                        Save Changes
                    </Button>
                </Stack>
                </Stack>
                <Grid container sx={{flexDirection: 'row', paddingLeft: 7, top: 10}}>
                    {isLoading === true ?
                        <Stack sx={{color: 'grey.500', paddingLeft: 55, paddingTop: 30}} spacing={2} direction="row"
                               justifyContent='center'>
                            <CircularProgress color="inherit"/>
                        </Stack>
                        :
                        <>
                            {operationClaimsByGroup.length > 0 ? (
                                <>
                                    {operationClaimsByGroup.map((row) => (

                                        <Card sx={{
                                            maxWidth: 295,
                                            minWidth: 295,
                                            marginTop: 5,
                                            marginRight: 5,
                                            maxHeight: 500
                                        }}>
                                            <CardContent>
                                                <Typography sx={{marginBottom:3.5, p: 2, borderBottom: '1px dashed #b1b9be',marginTop: -1}} gutterBottom variant="h6"
                                                            component="div" key={row.OperationClaimGroupId}>
                                                    {row.OperationClaimGroupName}
                                                </Typography>
                                                {row.OperationClaims.map((row1) => (
                                                    <>
                                                        <Stack sx={{flexDirection: 'row'}}>
                                                            <Checkbox
                                                                sx={{bottom: 10}}
                                                                checked={userClaimsOperations.includes(row1.Id)}
                                                                value={parseInt(row1.Id)}
                                                                onChange={(e) => handleSelectedClaimsId(e)}
                                                                inputProps={{'aria-label': 'controlled'}}
                                                            />
                                                            <Typography variant="body2" color="text.secondary"
                                                                        key={row1.Id}>
                                                                {row1.Name}
                                                            </Typography>

                                                        </Stack>
                                                    </>
                                                ))}
                                            </CardContent>
                                        </Card>
                                    ))}
                                </>
                            ) : (
                                <TableCell sx={{width: '40%'}}>
                                    <img src="/static/illustrations/no.png" alt="login"/>
                                    <Typography variant="h3" gutterBottom textAlign='center'
                                                color='#a9a9a9'>No Data Found</Typography>
                                </TableCell>
                            )}
                        </>
                    }
                </Grid>
            </Container>
        </Page>
    );
}

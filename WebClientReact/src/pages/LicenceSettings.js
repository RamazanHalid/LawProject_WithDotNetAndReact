// material
import {
    Stack,
    Container,
    Paper,
    Typography,
    Button,
    Box,
    TextField,
    InputAdornment,
    TableContainer,
    Table,
    TableHead,
    TableRow,
    TableCell,
    TableBody, Grid, IconButton, Link,
} from '@mui/material';
// layouts
// components
import Page from '../components/Page';
import {Icon} from "@iconify/react";
import plusFill from "@iconify/icons-eva/plus-fill";
import messageCircleOutline from '@iconify/icons-eva/message-circle-outline';
import peopleOutline from '@iconify/icons-eva/people-outline';
import Modal from "@mui/material/Modal";
import CloseIcon from "@material-ui/icons/Close";
import React, {useEffect, useState} from "react";
import PopupMessageService from 'src/services/popupMessage.service';
import {Global} from "../Global";
import roundUpdate from "@iconify/icons-ic/round-update";
import outlineAccountBalanceWallet from '@iconify/icons-ic/outline-account-balance-wallet';
import outlinePayment from '@iconify/icons-ic/outline-payment';
import outlinePersonOutline from '@iconify/icons-ic/outline-person-outline';
import FormControl from "@mui/material/FormControl";
import DriveFileRenameOutlineOutlinedIcon from "@mui/icons-material/DriveFileRenameOutlineOutlined";
import BusinessOutlinedIcon from "@mui/icons-material/BusinessOutlined";
import MenuItem from "@mui/material/MenuItem";
import AdminPanelSettingsOutlinedIcon from "@mui/icons-material/AdminPanelSettingsOutlined";
import HomeOutlinedIcon from "@mui/icons-material/HomeOutlined";
import AddBusinessOutlinedIcon from "@mui/icons-material/AddBusinessOutlined";
import HomeWorkOutlinedIcon from "@mui/icons-material/HomeWorkOutlined";
import WebOutlinedIcon from "@mui/icons-material/WebOutlined";
import EmailOutlinedIcon from "@mui/icons-material/EmailOutlined";
import PersonTypesService from "../services/personTypes.service";
import CityService from "../services/city.service";
import CountryService from "../services/country.service";
import LicencesService from "../services/licences.service";
import {Link as RouterLink, useNavigate, useParams} from "react-router-dom";
import {format} from "date-fns";
import PaymentHistoriesService from "../services/paymentHistories.service";
import CircularProgress from "@mui/material/CircularProgress";
import Scrollbar from "../components/Scrollbar";
import SmsOrdersService from "../services/smsOrders.service";
import CaseTypeBox from "../components/_dashboard/app/CaseTypeBox";
import ContinuingTasks from "../components/_dashboard/Box/ContinuingTasks";
import ClientSize from "../components/_dashboard/Box/ClientSize";
import CaseSize from "../components/_dashboard/Box/CaseSize";
import TransactionActivitySize from "../components/_dashboard/Box/TransactionActivitySize";
import CurrentBalance from "../components/_dashboard/Box/CurrentBalance";
import CurrentlyUsed from "../components/_dashboard/Box/CurrentlyUsed";
import NumberOfCurrent from "../components/_dashboard/Box/NumberOfCurrent";
import SMS from "../components/_dashboard/Box/SMS";
import palette from "../theme/palette";
import PublicOutlinedIcon from "@mui/icons-material/PublicOutlined";
import PhoneInTalkOutlinedIcon from "@mui/icons-material/PhoneInTalkOutlined";
import AuthService from "../services/auth.service";
// ----------------------------------------------------------------------

export default function LicenceSettings() {
    const [openPaymentHistories, setOpenPaymentHistories] = useState(false);
    const [openModalSMS, setOpenSMS] = useState(false);
    const [openEditLicence, setOpenEditLicence] = useState(false);
    const [profileNameEdit, setProfileNameEdit] = useState('');
    const [cityIdEdit, setCityIdEdit] = useState(0);
    const [personTypeEdit, setPersonTypeEdit] = useState();
    const [phoneNumberEdit, setPhoneNumberEdit] = useState('');
    const [billAddressEdit, setBillAddressEdit] = useState('');
    const [taxNoEdit, setTaxNoEdit] = useState('');
    const [taxOfficeEdit, setTaxOfficeEdit] = useState('');
    const [websiteEdit, setWebSiteEdit] = useState('');
    const [emailEdit, setEmailEdit] = useState('');
    const [imageFile, setImageFile] = useState('');
    const [openModal, setOpen] = useState(false);
    const [cities, setCities] = useState([]);
    const [personTypeList, setPersonTypeList] = useState([]);
    const [countryId, setCountryId] = useState(0);
    const [histories, setHistories] = useState([]);
    const [smsOrders, setSmsOrders] = useState([]);
    const [isLoading, setIsLoading] = useState(true);
    const [profilNameAdd, setProfilNameAdd] = useState("");
    const [userIdAdd, setUserIdAdd] = useState(0);
    const [personTypeIdAdd, setPersonTypeIdAdd] = useState(1);
    const [billAddressAdd, setBillAddressAdd] = useState("");
    const [taxNoAdd, setTaxNoAdd] = useState("");
    const [taxOfficeAdd, setTaxOfficeAdd] = useState("");
    const [webSiteAdd, setWebSiteAdd] = useState("");
    const [emailAdd, setEmailAdd] = useState("");
    const [phoneNumberAdd, setPhoneNumberAdd] = useState("");
    const [cityIdAdd, setCityIdAdd] = useState(0);
    const [valueR, setValueR] = useState('');
    const [cityValue, setCityValue] = useState(0);
    const [isCountrySelected, setIsCountrySelected] = useState(false);
    const [countries, setCountries] = useState([]);

    const {id} = useParams();
    const catchMessagee = Global.catchMessage;
    const personTypesService = new PersonTypesService();
    const smsOrdersService = new SmsOrdersService();
    const authService= new AuthService();
    const licencesService = new LicencesService();
    const cityService = new CityService();
    const countryService = new CountryService();
    const popupMessageService = new PopupMessageService();
    const paymentHistoriesService = new PaymentHistoriesService();

    const handleClosePaymentHistories = () => {
        setOpenPaymentHistories(false);
    };
    const handleCloseSMS = () => {
        setOpenSMS(false);
    };
    const handleOpenSMS = () => {
        setOpenSMS(true);
    };
    const handleOpenPaymentHistories = () => {
        setOpenPaymentHistories(true);
    };
    const handleOpenEditLicence = () => {
        setOpenEditLicence(true);
    };

    function licenceInfo() {
        licencesService.getForUpdating().then(result => {
                if (result.data.Success) {
                    let info = result.data.Data
                    setImageFile(info.ImageFile)
                    setPersonTypeEdit(info.PersonType.PersonTypeId)
                    setBillAddressEdit(info.BillAddress)
                    setTaxNoEdit(info.TaxNo)
                    setTaxOfficeEdit(info.TaxOffice)
                    setWebSiteEdit(info.WebSite)
                    setEmailEdit(info.Email)
                    setPhoneNumberEdit(info.PhoneNumber)
                    setCityIdEdit(info.City.CityId)
                    setProfileNameEdit(info.ProfilName)
                }
            }, (error) => {
                console.log()(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        });
    }

    const getAllPersonTypes = () => {
        personTypesService
            .getAll()
            .then((result) => {
                    setPersonTypeList(result.data.Data);
                    const personTypesFromApi = result.data.Data;
                    const list2 = [];
                    personTypesFromApi.forEach((item) => {
                        list2.push({
                            value: item.PersonTypeId,
                            label: item.PersonTypeName,
                            key: item.PersonTypeName
                        });
                    });
                    setPersonTypeList(list2);
                }, (error) => {
                    console.log()(error.response.data.Message);
                }
            ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        });
    }

    const editLicence = () => {
        let obj = {
            profilName: profileNameEdit,
            userId: id,
            personTypeId: personTypeEdit,
            billAddress: billAddressEdit,
            taxNo: taxNoEdit,
            taxOffice: taxOfficeEdit,
            webSite: websiteEdit,
            email: emailEdit,
            phoneNumber: phoneNumberEdit,
            cityId: cityIdEdit
        }
        let re = licencesService.update(obj)
        re.then(
            (result) => {
                if (result.data.Success) {
                    setOpenEditLicence(false)
                    popupMessageService.AlertSuccessMessage(result.data.Message)
                }
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    };

    const getAllCountries = () => {
        countryService
            .getAll()
            .then((result) => {
                setCountryId(result.data.Data.CountryId);
            })
    }

    const getAllCities = () => {
        cityService
            .getAll(1)
            .then((result) => {
                setCities(result.data.Data);
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
            })
            .catch(() => {
                popupMessageService.AlertErrorMessage(catchMessagee)
            });
    }

    const getAllPaymentHistories = () => {
        paymentHistoriesService.getAll().then(
            (result) => {
                if (result.data.Success) {
                    setHistories(result.data.Data)
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
    const getAllSmsOrders = () => {
        smsOrdersService.getAll().then(
            (result) => {
                if (result.data.Success) {
                    setSmsOrders(result.data.Data)
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

    const getBuyTheSms = (id) => {
        smsOrdersService.buyTheSms(id).then(
            (result) => {
                if (result.data.Success) {
                    setOpenSMS(false)
                    popupMessageService.AlertSuccessMessage(result.data.Message);
                }
            },
            (error) => {
                setOpenSMS(false)
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            setOpenSMS(false)
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    };

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

    const addNewLicence = () => {
        let obj = {
            profilName: profilNameAdd,
            userId: id,
            personTypeId: personTypeIdAdd,
            billAddress: billAddressAdd,
            taxNo: taxNoAdd,
            taxOffice: taxOfficeAdd,
            webSite: webSiteAdd,
            email: emailAdd,
            phoneNumber: phoneNumberAdd,
            cityId: cityIdAdd
        }
        let re = licencesService.add(obj)
        re.then(
            (result) => {
                if (result.data.Success) {
                    setOpen(false)
                    popupMessageService.AlertSuccessMessage(result.data.Message)
                }
            },
            (error) => {
                console.log()(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    };

    const getAllPersonTypess = () => {
        personTypesService
            .getAll()
            .then((result) => {
                    setPersonTypeList(result.data.Data);
                    const personTypesFromApi = result.data.Data;
                    const list2 = [];
                    personTypesFromApi.forEach((item) => {
                        list2.push({
                            value: item.PersonTypeId,
                            label: item.PersonTypeName,
                            key: item.PersonTypeName
                        });
                    });
                    setPersonTypeIdAdd(list2[0].value)
                    setPersonTypeList(list2);
                },
                (error) => {
                    popupMessageService.AlertErrorMessage(error.response.data.Message);
                })
            .catch(() => {
                popupMessageService.AlertErrorMessage(catchMessagee)
            });
    }

    const handleOpen = () => {
        setProfilNameAdd('')
        setUserIdAdd(0)
        setPersonTypeIdAdd(0)
        setBillAddressAdd('')
        setTaxNoAdd('')
        setTaxOfficeAdd('')
        setWebSiteAdd('')
        setWebSiteAdd('')
        setEmailAdd('')
        setPhoneNumberAdd('')
        setCityIdAdd(0)
        setOpen(true);
    };
    const handleClose = () => {
        setOpen(false);
    };

    useEffect(() => {
        getAllCities();
        getAllPersonTypes();
        getAllPersonTypess();
        licenceInfo();
        getAllCountries();
        getAllPaymentHistories();
        getAllSmsOrders();
    }, [])

    return (

        <Page title="Licence Settings | MediLaw">
            <Container>
                <Stack direction="row" alignItems="center" justifyContent="space-between" mb={4}>
                    <Typography variant="h4" gutterBottom>
                        Licence Settings
                    </Typography>
                </Stack>
                {authService.DoesHaveMandatoryClaim('LicenceOwner') ? (
                    <>
                <Grid container spacing={3}>
                    <Grid item xs={12} sm={6} md={3}>
                        <ContinuingTasks />
                    </Grid>
                    <Grid item xs={12} sm={6} md={3}>
                        <ClientSize />
                    </Grid>
                    <Grid item xs={12} sm={6} md={3}>
                        <CaseSize />
                    </Grid>
                    <Grid item xs={12} sm={6} md={3}>
                        <TransactionActivitySize />
                    </Grid>
                    <Grid item xs={12} sm={6} md={3}>
                        <CurrentBalance />
                    </Grid>
                    <Grid item xs={12} sm={6} md={3}>
                        <CurrentlyUsed />
                    </Grid>
                    <Grid item xs={12} sm={6} md={3}>
                        <NumberOfCurrent />
                    </Grid>
                    <Grid item xs={12} sm={6} md={3}>
                        <SMS />
                    </Grid>
                </Grid>
                <Grid container sx={{ paddingTop: 5, flexDirection: 'row'}}>
                <Button to={'/dashboard/licenceSettings/addUsers'} component={RouterLink} variant="contained"
                        startIcon={<Icon icon={peopleOutline}/>}>
                    Users
                </Button>
                <Button to={'/dashboard/licenceSettings/balance'} component={RouterLink} sx={{left: '2%'}} variant="contained"
                        startIcon={<Icon icon={plusFill}/>}>
                    Add balance
                </Button>
                <Button to={'/dashboard/licenceSettings/userList'} component={RouterLink} sx={{left: '4%'}} variant="contained"
                        startIcon={<Icon icon={outlinePersonOutline}/>}>
                    User List
                </Button>
                <Button
                    sx={{left: '6%'}} onClick={handleOpenSMS} variant="contained"
                    startIcon={<Icon icon={messageCircleOutline}/>}>
                    SMS Order
                </Button>
                <Modal sx={{backgroundColor: "rgba(0, 0, 0, 0.5)"}}
                       hideBackdrop={true}
                       disableEscapeKeyDown={true}
                       open={openModalSMS}
                       aria-labelledby="modal-modal-title"
                       aria-describedby="modal-modal-description"
                >
                    <Box
                        sx={{
                            position: 'absolute',
                            top: '50%',
                            left: '50%',
                            transform: 'translate(-50%, -50%)',
                            minWidth:500,
                            maxWidth: 750,
                            minHeight:270,
                            maxHeight: 650,
                            backgroundColor: 'background.paper',
                            border: '2px solid #fff',
                            boxShadow: 24,
                            p: 4,
                            borderRadius: 2
                        }}
                    >
                        <Stack mb={4} flexDirection="row" justifyContent='space-between'>
                            <Typography id="modal-modal-title" variant="h6" component="h2">
                                SMS Package!
                            </Typography>
                            <IconButton>
                            <CloseIcon onClick={handleCloseSMS}/>
                            </IconButton>
                        </Stack>
                        <Stack spacing={2}>
                            {smsOrders.length > 0 ? (
                                <>
                                        <TableContainer component={Paper}>
                                <Table sx={{minWidth: 650}} aria-label="simple table">
                                    <TableHead>
                                        <TableRow sx={{backgroundColor: '#f7f7f7'}}>
                                            <TableCell align="left" sx={{ paddingLeft: 5 }}>Name</TableCell>
                                            <TableCell align="left">Price</TableCell>
                                            <TableCell align="left">Unit Price</TableCell>
                                            <TableCell align="left">SMS Count</TableCell>
                                            <TableCell align="left">Buy SMS</TableCell>
                                        </TableRow>
                                    </TableHead>
                                    <TableBody>
                                        {smsOrders.map((row) => (
                                            <TableRow
                                                key={row.Id}
                                                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                                            >
                                                <TableCell component="th" scope="row" sx={{ paddingLeft: 5 }}>
                                                    {row.Name}
                                                </TableCell>
                                                <TableCell component="th" scope="row" sx={{ paddingLeft: 3.5 }}>
                                                    {row.Price}
                                                </TableCell>
                                                <TableCell component="th" scope="row" sx={{ paddingLeft: 5 }}>
                                                {row.PricePerUnit}
                                            </TableCell>
                                                <TableCell component="th" scope="row" sx={{ paddingLeft: 6 }}>
                                                    {row.SmsCount}
                                                </TableCell>
                                                <TableCell align="left">
                                                    <Button
                                                        variant="contained"
                                                        onClick={() => getBuyTheSms(row.Id)}
                                                        sx={{backgroundColor:  palette.green.dark}}
                                                        startIcon={<Icon icon={outlineAccountBalanceWallet} />}
                                                    >
                                                        Buy SMS
                                                    </Button>
                                                </TableCell>
                                            </TableRow>
                                        ))}
                                    </TableBody>
                                </Table>
                            </TableContainer>

                                </>
                            ) : (
                                <TableCell sx={{width: '40%'}}>
                                    <img src="/static/illustrations/no.png" alt="login"/>
                                    <Typography variant="h3" gutterBottom textAlign='center'
                                                color='#a9a9a9'>No Data Found</Typography>
                                </TableCell>
                            )}
                        </Stack>
                    </Box>
                </Modal>
                    <Button onClick={handleOpen} sx={{left: '8%'}} variant="contained"
                            startIcon={<Icon icon={plusFill}/>}>
                        Add Licence!
                    </Button>
                    <Modal sx={{backgroundColor: "rgba(0, 0, 0, 0.5)"}}
                           hideBackdrop={true}
                           disableEscapeKeyDown={true}
                           open={openModal}
                           aria-labelledby="modal-modal-title"
                           aria-describedby="modal-modal-description"
                    >
                        <Box
                            sx={{
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
                            }}
                        >
                            <Stack mb={5} flexDirection="row" justifyContent='space-between'>
                                <Typography id="modal-modal-title" variant="h6" component="h2">
                                    Add new licence!
                                </Typography>
                                <CloseIcon onClick={handleClose}/>
                            </Stack>
                            <Stack spacing={2}>
                                <Stack mb={3} alignItems="center" justifyContent="space-around">
                                    <Stack mb={3} justifyContent="space-around">
                                        <Box sx={{minWidth: 400}}>
                                            <FormControl fullWidth size="small">
                                                <TextField
                                                    autoFocus
                                                    fullWidth
                                                    size="small"
                                                    label="Licence Name"
                                                    value={profilNameAdd}
                                                    onChange={(event) => setProfilNameAdd(event.target.value)}
                                                    InputProps={{
                                                        startAdornment: (
                                                            <InputAdornment position="start">
                                                                <DriveFileRenameOutlineOutlinedIcon/>
                                                            </InputAdornment>
                                                        )
                                                    }}
                                                />
                                            </FormControl>
                                        </Box>
                                    </Stack>
                                    {countries.length > 0 ? (
                                        <Stack mb={3} justifyContent="space-around">
                                            <Box sx={{minWidth: 400}}>
                                                <FormControl fullWidth>
                                                    <TextField
                                                        select
                                                        fullWidth
                                                        size='small'
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
                                                            <MenuItem key={Math.random().toString(36).substr(2, 9)}
                                                                      value={item.value}>
                                                                {item.label}
                                                            </MenuItem>
                                                        ))}
                                                    </TextField>
                                                </FormControl>
                                            </Box>
                                        </Stack>
                                    ) : null}

                                    {cities.length > 0 && isCountrySelected ? (
                                        <Stack mb={3} justifyContent="space-around">
                                            <Box sx={{minWidth: 400}}>
                                                <FormControl fullWidth>
                                                    <TextField
                                                        select
                                                        fullWidth
                                                        size='small'
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
                                                            <MenuItem key={Math.random().toString(36).substr(2, 9)}
                                                                      value={item.value}>
                                                                {item.label}
                                                            </MenuItem>
                                                        ))}
                                                    </TextField>
                                                </FormControl>
                                            </Box>
                                        </Stack>
                                    ) : null}

                                    {personTypeList.length > 0 ? (
                                        <Box mb={3} sx={{minWidth: 400}}>
                                            <FormControl fullWidth size='small'>
                                                <TextField
                                                    select
                                                    size='small'
                                                    value={personTypeIdAdd}
                                                    key={Math.random().toString(36).substr(2, 9)}
                                                    label="Person Type"
                                                    onChange={(event) => setPersonTypeIdAdd(event.target.value)}
                                                    InputProps={{
                                                        startAdornment: (
                                                            <InputAdornment position="start">
                                                                <AdminPanelSettingsOutlinedIcon/>
                                                            </InputAdornment>
                                                        )
                                                    }}
                                                >
                                                    {personTypeList.map((item) => (
                                                        <MenuItem key={Math.random().toString(36).substr(2, 9)}
                                                                  value={item.value}>
                                                            {item.label}
                                                        </MenuItem>
                                                    ))}
                                                </TextField>
                                            </FormControl>
                                        </Box>
                                    ) : null}

                                    <Stack mb={3} direction={{xs: 'column', sm: 'row'}} spacing={2}>
                                        <TextField
                                            fullWidth
                                            size="small"
                                            label="Phone Number"
                                            value={phoneNumberAdd}
                                            onChange={(event) => setPhoneNumberAdd(event.target.value)}
                                            InputProps={{
                                                startAdornment: (
                                                    <InputAdornment position="start">
                                                        <PhoneInTalkOutlinedIcon/>
                                                    </InputAdornment>
                                                )
                                            }}
                                        />
                                        <TextField
                                            fullWidth
                                            size="small"
                                            label="Bill Adress"
                                            value={billAddressAdd}
                                            onChange={(event) => setBillAddressAdd(event.target.value)}
                                            InputProps={{
                                                startAdornment: (
                                                    <InputAdornment position="start">
                                                        <HomeOutlinedIcon/>
                                                    </InputAdornment>
                                                )
                                            }}
                                        />
                                    </Stack>
                                    <Stack mb={3} direction={{xs: 'column', sm: 'row'}} spacing={2}>
                                        <TextField
                                            fullWidth
                                            size="small"
                                            label="Tax No"
                                            value={taxNoAdd}
                                            onChange={(event) => setTaxNoAdd(event.target.value)}
                                            InputProps={{
                                                startAdornment: (
                                                    <InputAdornment position="start">
                                                        <AddBusinessOutlinedIcon/>
                                                    </InputAdornment>
                                                )
                                            }}
                                        />
                                        <TextField
                                            fullWidth
                                            size="small"
                                            label="Tax Office"
                                            value={taxOfficeAdd}
                                            onChange={(event) => setTaxOfficeAdd(event.target.value)}
                                            InputProps={{
                                                startAdornment: (
                                                    <InputAdornment position="start">
                                                        <HomeWorkOutlinedIcon/>
                                                    </InputAdornment>
                                                )
                                            }}
                                        />
                                    </Stack>
                                    <Stack direction={{xs: 'column', sm: 'row'}} spacing={2}>
                                        <TextField
                                            fullWidth
                                            size="small"
                                            label="Website"
                                            value={webSiteAdd}
                                            onChange={(event) => setWebSiteAdd(event.target.value)}
                                            InputProps={{
                                                startAdornment: (
                                                    <InputAdornment position="start">
                                                        <WebOutlinedIcon/>
                                                    </InputAdornment>
                                                )
                                            }}
                                        />
                                        <TextField
                                            fullWidth
                                            size="small"
                                            label="Email"
                                            value={emailAdd}
                                            onChange={(event) => setEmailAdd(event.target.value)}
                                            InputProps={{
                                                startAdornment: (
                                                    <InputAdornment position="start">
                                                        <EmailOutlinedIcon/>
                                                    </InputAdornment>
                                                )
                                            }}
                                        />
                                    </Stack>
                                </Stack>
                                <Button
                                    size="large"
                                    type="submit"
                                    variant="contained"
                                    onClick={() => addNewLicence()}
                                >
                                    Add!
                                </Button>
                            </Stack>
                        </Box>
                    </Modal>
                    <Button onClick={handleOpenEditLicence} sx={{left: '10%'}} variant="contained"
                            startIcon={<Icon icon={roundUpdate}/>}>
                        Edit Licence
                    </Button>
                    <Modal sx={{backgroundColor: "rgba(0, 0, 0, 0.5)"}}
                           hideBackdrop={true}
                           disableEscapeKeyDown={true}
                           open={openEditLicence}
                           aria-labelledby="modal-modal-title"
                           aria-describedby="modal-modal-description"
                    >
                        <Box
                            sx={{
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
                            }}
                        >
                            <Stack mb={5} flexDirection="row" justifyContent='space-between'>
                                <Typography id="modal-modal-title" variant="h6" component="h2">
                                    Edit licence!
                                </Typography>
                                <IconButton>
                                    <CloseIcon onClick={() => setOpenEditLicence(false)}/>
                                </IconButton>
                            </Stack>
                            <Stack spacing={2}>
                                <Stack mb={3} alignItems="center" justifyContent="space-around">
                                    <Stack mb={3} justifyContent="space-around">
                                        <Box sx={{minWidth: 400}}>
                                            <FormControl fullWidth size="small">
                                                <TextField
                                                    autoFocus
                                                    fullWidth
                                                    size="small"
                                                    label="Licence Name"
                                                    value={profileNameEdit}
                                                    onChange={(event) => setProfileNameEdit(event.target.value)}
                                                    InputProps={{
                                                        startAdornment: (
                                                            <InputAdornment position="start">
                                                                <DriveFileRenameOutlineOutlinedIcon/>
                                                            </InputAdornment>
                                                        )
                                                    }}
                                                />
                                            </FormControl>
                                        </Box>
                                    </Stack>
                                    {cities.length > 0 ? (
                                        <Box mb={3} sx={{minWidth: 400}}>
                                            <FormControl fullWidth size='small'>
                                                <TextField
                                                    select
                                                    size='small'
                                                    value={cityIdEdit}
                                                    key={Math.random().toString(36).substr(2, 9)}
                                                    label="City"
                                                    onChange={(event) => setCityIdEdit(event.target.value)}
                                                    InputProps={{
                                                        startAdornment: (
                                                            <InputAdornment position="start">
                                                                <BusinessOutlinedIcon/>
                                                            </InputAdornment>
                                                        )
                                                    }}
                                                >
                                                    {cities.map((item) => (
                                                        <MenuItem key={Math.random().toString(36).substr(2, 9)}
                                                                  value={item.value}>
                                                            {item.label}
                                                        </MenuItem>
                                                    ))}
                                                </TextField>
                                            </FormControl>
                                        </Box>
                                    ) : null}
                                    {personTypeList.length > 0 ? (
                                        <Box mb={3} sx={{minWidth: 400}}>
                                            <FormControl fullWidth size='small'>
                                                <TextField
                                                    select
                                                    size='small'
                                                    value={personTypeEdit}
                                                    key={Math.random().toString(36).substr(2, 9)}
                                                    label="Person Type"
                                                    onChange={(event) => setPersonTypeEdit(event.target.value)}
                                                    InputProps={{
                                                        startAdornment: (
                                                            <InputAdornment position="start">
                                                                <AdminPanelSettingsOutlinedIcon/>
                                                            </InputAdornment>
                                                        )
                                                    }}
                                                >
                                                    {personTypeList.map((item) => (
                                                        <MenuItem key={Math.random().toString(36).substr(2, 9)}
                                                                  value={item.value}>
                                                            {item.label}
                                                        </MenuItem>
                                                    ))}
                                                </TextField>
                                            </FormControl>
                                        </Box>
                                    ) : null}
                                    <Box mb={3} sx={{minWidth: 400}}>
                                        <FormControl fullWidth size='small'>
                                            <TextField
                                                fullWidth
                                                size="small"
                                                label="Bill Adress"
                                                multiline
                                                value={billAddressEdit}
                                                onChange={(event) => setBillAddressEdit(event.target.value)}
                                                InputProps={{
                                                    startAdornment: (
                                                        <InputAdornment position="start">
                                                            <HomeOutlinedIcon/>
                                                        </InputAdornment>
                                                    )
                                                }}
                                            />
                                        </FormControl>
                                    </Box>
                                    <Stack mb={3} direction={{xs: 'column', sm: 'row'}} spacing={2}>
                                        <TextField
                                            fullWidth
                                            size="small"
                                            label="Tax No"
                                            value={taxNoEdit}
                                            onChange={(event) => setTaxNoEdit(event.target.value)}
                                            InputProps={{
                                                startAdornment: (
                                                    <InputAdornment position="start">
                                                        <AddBusinessOutlinedIcon/>
                                                    </InputAdornment>
                                                )
                                            }}
                                        />
                                        <TextField
                                            fullWidth
                                            size="small"
                                            label="Tax Office"
                                            value={taxOfficeEdit}
                                            onChange={(event) => setTaxOfficeEdit(event.target.value)}
                                            InputProps={{
                                                startAdornment: (
                                                    <InputAdornment position="start">
                                                        <HomeWorkOutlinedIcon/>
                                                    </InputAdornment>
                                                )
                                            }}
                                        />
                                    </Stack>
                                    <Stack direction={{xs: 'column', sm: 'row'}} spacing={2}>
                                        <TextField
                                            fullWidth
                                            size="small"
                                            label="Website"
                                            value={websiteEdit}
                                            onChange={(event) => setWebSiteEdit(event.target.value)}
                                            InputProps={{
                                                startAdornment: (
                                                    <InputAdornment position="start">
                                                        <WebOutlinedIcon/>
                                                    </InputAdornment>
                                                )
                                            }}
                                        />
                                        <TextField
                                            fullWidth
                                            size="small"
                                            label="Email"
                                            value={emailEdit}
                                            onChange={(event) => setEmailEdit(event.target.value)}
                                            InputProps={{
                                                startAdornment: (
                                                    <InputAdornment position="start">
                                                        <EmailOutlinedIcon/>
                                                    </InputAdornment>
                                                )
                                            }}
                                        />
                                    </Stack>
                                </Stack>
                                <Button
                                    size="large"
                                    type="submit"
                                    variant="contained"
                                    onClick={() => editLicence()}
                                >
                                    Edit!
                                </Button>
                            </Stack>
                        </Box>
                    </Modal>
                <Button onClick={handleOpenPaymentHistories} sx={{left: '12%'}} variant="contained"
                        startIcon={<Icon icon={outlinePayment}/>}>
                    Payment History
                </Button>
                <Modal sx={{backgroundColor: "rgba(0, 0, 0, 0.5)"}}
                       hideBackdrop={true}
                       disableEscapeKeyDown={true}
                       open={openPaymentHistories}
                       aria-labelledby="modal-modal-title"
                       aria-describedby="modal-modal-description"
                >
                    <Box
                        sx={{
                            position: 'absolute',
                            top: '50%',
                            left: '50%',
                            transform: 'translate(-50%, -50%)',
                            width: 470,
                            maxHeight: 550,
                            backgroundColor: 'background.paper',
                            border: '2px solid #fff',
                            boxShadow: 24,
                            p: 4,
                            borderRadius: 2
                        }}
                    >
                        <Stack mb={5} flexDirection="row" justifyContent='space-between'>
                            <Typography id="modal-modal-title" variant="h6" component="h2">
                                Payment History!
                            </Typography>
                            <IconButton>
                            <CloseIcon onClick={handleClosePaymentHistories}/>
                            </IconButton>
                        </Stack>
                        <Scrollbar>
                            {isLoading === true ?
                                <Stack sx={{color: 'grey.500', padding: 10}} spacing={2} direction="row"
                                       justifyContent='center'>
                                    <CircularProgress color="inherit"/>
                                </Stack>
                                :
                                <>
                                    {histories.length > 0 ? (
                                        <TableContainer component={Paper} sx={{maxHeight: 400}}>
                                            <Table sx={{minWidth: 300}} aria-label="simple table">
                                                <TableHead>
                                                    <TableRow sx={{backgroundColor: '#f7f7f7'}}>
                                                        <TableCell sx={{paddingLeft: 5}}>Balance</TableCell>
                                                        <TableCell sx={{paddingLeft: 7}}>Payment Day</TableCell>
                                                    </TableRow>
                                                </TableHead>
                                                <TableBody>
                                                    <>
                                                        {histories.map((row) => (
                                                            <TableRow
                                                                key={row.Id}
                                                                sx={{'&:last-child td, &:last-child th': {border: 0}}}
                                                            >
                                                                <TableCell component="th" scope="row"
                                                                           sx={{paddingLeft: 7}}>
                                                                    {row.Balance} ₺
                                                                </TableCell>
                                                                <TableCell component="th" scope="row"
                                                                           sx={{paddingLeft: 7}}>
                                                                    {format(new Date(row.PaymentDate), 'dd/MM/yyyy')}
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
                                            <Typography variant="h3" gutterBottom textAlign='center'
                                                        color='#a9a9a9'>No Data Found</Typography>
                                        </TableCell>
                                    )}
                                </>
                            }
                        </Scrollbar>
                    </Box>
                </Modal>
                </Grid>
                    </>
                ): <Typography>Sorry, you don't have the authorization to perform this action!</Typography>}
            </Container>
        </Page>
    );
}

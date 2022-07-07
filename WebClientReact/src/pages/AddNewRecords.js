import * as Yup from 'yup';
import { useEffect, useState } from 'react';
import { Link as RouterLink, Navigate, useNavigate } from 'react-router-dom';

// material
import {
  Stack,
  Button,
  Typography,
  TableContainer,
  Table,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
  Box,
  Paper
} from '@mui/material';
import { LoadingButton } from '@mui/lab';
import FormControl from '@mui/material/FormControl';
import InputLabel from '@mui/material/InputLabel';
import Select from '@mui/material/Select';
import MenuItem from '@mui/material/MenuItem';
import { Icon } from '@iconify/react';
import plusFill from '@iconify/icons-eva/plus-fill';
import Modal from '@mui/material/Modal';
import authService from '../services/auth.service';
import CourtOfficeTypesService from '../services/courtOfficeType.service';

// ----------------------------------------------------------------------

export default function AddNewRecords() {
  const [usr, setUsr] = useState();
  const [courtOff, setCourtOff] = useState('');
  const [courtOfficeTypes, setCourtOfficeTypes] = useState([]);
  const [open, setOpen] = useState(false);
  const handleOpen = () => {
    setOpen(true);
  };
  const handleClose = () => {
    setOpen(false);
  };
  const courtOffice = () => {
    const courtOfficeTypesService = new CourtOfficeTypesService();
    courtOfficeTypesService
      .getAll()
      .then(
        (response) => {
          setCourtOfficeTypes(response.data.Data);
          const CourtOfficeFromApi = response.data.Data;
          const list = [];
          // eslint-disable-next-line no-restricted-syntax,guard-for-in
          CourtOfficeFromApi.forEach((item) => {
            list.push({
              value: item.CourtOfficeTypeId,
              label: item.CourtOfficeTypeName,
              key: item.CourtOfficeTypeName
            });
          });
          setCourtOfficeTypes(list);
        },
        (error) => {
          console.log(error.response.data);
        }
      )
      .catch((errors) => {
        console.log(errors);
      });
  };
  useEffect(() => {
    courtOffice();
  }, []);
  const handleChange = (event) => {
    setCourtOff(event.target.value);
  };

  return (
    <Stack spacing={2.5}>
      <Modal
        open={open}
        onClose={handleClose}
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
          <Stack spacing={3}>
            <Typography id="modal-modal-title" variant="h6" component="h2">
              Add new record!
            </Typography>
            <Stack mb={1} alignItems="center" justifyContent="space-around">
              <Stack mb={3} justifyContent="space-around">
                <Typography variant="body1" gutterBottom>
                  Court Office
                </Typography>
                {courtOfficeTypes.length > 0 ? (
                  <Box sx={{ minWidth: 400 }}>
                    <FormControl fullWidth size="small">
                      <InputLabel id="demo-simple-select-label">Court Office</InputLabel>
                      <Select
                        labelId="demo-simple-select-label"
                        id="demo-simple-select"
                        value={courtOff}
                        key={Math.random().toString(36).substr(2, 9)}
                        label="Select Country"
                        onChange={handleChange}
                      >
                        {courtOfficeTypes.map((item) => (
                          <MenuItem
                            key={Math.random().toString(36).substr(2, 9)}
                            value={item.value}
                          >
                            {item.label}
                          </MenuItem>
                        ))}
                      </Select>
                    </FormControl>
                  </Box>
                ) : null}
              </Stack>
              <Stack mb={1} justifyContent="space-around">
                <Typography variant="body1" gutterBottom>
                  Status
                </Typography>
                <Box sx={{ minWidth: 400 }}>
                  <FormControl fullWidth size="small">
                    <InputLabel id="demo-simple-select-label">Status</InputLabel>
                    <Select
                      labelId="demo-simple-select-label"
                      id="demo-simple-select"
                      value={courtOff}
                      key={Math.random().toString(36).substr(2, 9)}
                      label="Select Country"
                      onChange={handleChange}
                    >
                      {courtOfficeTypes.map((item) => (
                        <MenuItem key={Math.random().toString(36).substr(2, 9)} value={item.value}>
                          {item.label}
                        </MenuItem>
                      ))}
                    </Select>
                  </FormControl>
                </Box>
              </Stack>
            </Stack>
            <Button size="large" type="submit" variant="contained" loading={false}>
              Add!
            </Button>
          </Stack>
        </Box>
      </Modal>
    </Stack>
  );
}

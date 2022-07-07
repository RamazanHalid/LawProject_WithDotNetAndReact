import PropTypes from 'prop-types';
// material
import { MenuItem, TextField } from '@mui/material';

// ----------------------------------------------------------------------

FolderPosts.propTypes = {
  options: PropTypes.array,
  onSort: PropTypes.func
};

export default function FolderPosts({ options, onSort }) {
  return (
    <TextField sx={{ width: 200 }} select size="small" value="All" onChange={onSort}>
      {options.map((option) => (
        <MenuItem key={option.value} value={option.value}>
          {option.label}
        </MenuItem>
      ))}
    </TextField>
  );
}

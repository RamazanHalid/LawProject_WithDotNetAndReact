import PropTypes from 'prop-types';
// material
import { MenuItem, TextField } from '@mui/material';

// ----------------------------------------------------------------------

BlogPosts.propTypes = {
  options: PropTypes.array,
  onSort: PropTypes.func
};

export default function BlogPosts({ options, onSort }) {
  return (
    <TextField sx={{ width: 300 }} select size="small" value="All" onChange={onSort}>
      {options.map((option) => (
        <MenuItem key={option.value} value={option.value}>
          {option.label}
        </MenuItem>
      ))}
    </TextField>
  );
}

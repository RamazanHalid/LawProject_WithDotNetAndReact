import PropTypes from 'prop-types';
import {forwardRef} from 'react';
// material
import { Box} from '@mui/material';
import CircularProgress from "@mui/material/CircularProgress";
// ----------------------------------------------------------------------
const Loader = forwardRef(({children, title = '', ...other}, ref) => (
    <Box ref={ref} {...other}>
        <CircularProgress color="inherit"/>
        {children}
    </Box>
));

Loader.propTypes = {
    children: PropTypes.node.isRequired,
    title: PropTypes.string
};

export default Loader;


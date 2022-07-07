import sharpEventNote from '@iconify/icons-ic/sharp-event-note';
// material
import {styled} from '@mui/material/styles';
import {Card, Typography, Stack} from '@mui/material';
import {Icon} from "@iconify/react";
// ----------------------------------------------------------------------

const RootStyle = styled(Card)(({theme}) => ({
    boxShadow: 'none',
    textAlign: 'center',
    paddingTop: 40,
    paddingRight: 50,
    color: '#a37e6e',
    backgroundColor: '#f7eae3',
    width: 310,
    height: 184
}));

const IconWrapperStyle = styled('div')(({ theme }) => ({
    margin: 'auto',
    display: 'flex',
    borderRadius: '50%',
    marginLeft: -20,
    paddingTop: 0,
    alignItems: 'center',
    width: theme.spacing(20),
    height: theme.spacing(17),
    justifyContent: 'center',
    color: '#a37e6e',
}));

// ----------------------------------------------------------------------

export default function ConnectedEvents() {
    return (

        <RootStyle>
            <Stack flexDirection='row' mt={2}>
                <IconWrapperStyle>
                    <Icon icon={sharpEventNote} width={350} height={350}/>
                </IconWrapperStyle>
                <Stack flexDirection='column'>
                    <Typography variant="h3" sx={{}}>
                        7
                    </Typography>
                    <Typography variant="subtitle1" paddingLeft={0} paddingTop={1}>
                        Connected Events
                    </Typography>
                </Stack>
            </Stack>
        </RootStyle>
    );
}

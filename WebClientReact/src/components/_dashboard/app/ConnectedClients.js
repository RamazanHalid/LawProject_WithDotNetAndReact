import baselinePerson from '@iconify/icons-ic/baseline-person';
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
    color: '#6e7ea3',
    backgroundColor: '#d7e1f4',
    width: 310,
    height: 184
}));

const IconWrapperStyle = styled('div')(({ theme }) => ({
    margin: 'auto',
    display: 'flex',
    borderRadius: '50%',
    marginLeft: -28,
    paddingTop: 0,
    alignItems: 'center',
    width: theme.spacing(22),
    height: theme.spacing(19),
    justifyContent: 'center',
    color: '#6e7ea3',
}));

// ----------------------------------------------------------------------

export default function ConnectedClients() {
    return (

        <RootStyle>
            <Stack flexDirection='row' mt={2}>
                <IconWrapperStyle>
                    <Icon icon={baselinePerson} width={350} height={350}/>
                </IconWrapperStyle>
                <Stack flexDirection='column'>
                <Typography variant="h3" sx={{}}>
                    10
                </Typography>
                <Typography variant="subtitle1" paddingLeft={0} paddingTop={1}>
                    Connected Clients
                </Typography>
                </Stack>
            </Stack>
        </RootStyle>
    );
}

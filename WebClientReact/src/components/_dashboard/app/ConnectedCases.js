// material
import {styled} from '@mui/material/styles';
import {Card, Typography, Stack} from '@mui/material';
import {Icon} from "@iconify/react";
import roundCases from '@iconify/icons-ic/round-cases';
// ----------------------------------------------------------------------

const RootStyle = styled(Card)(({theme}) => ({
    boxShadow: 'none',
    textAlign: 'center',
    paddingTop: 40,
    paddingRight: 50,
    color: '#639674',
    backgroundColor: '#e3f7e7',
    width: 310,
    height: 184
}));

const IconWrapperStyle = styled('div')(({ theme }) => ({
    margin: 'auto',
    display: 'flex',
    borderRadius: '50%',
    marginLeft: -40,
    paddingTop: 0,
    alignItems: 'center',
    width: theme.spacing(22),
    height: theme.spacing(23),
    justifyContent: 'center',
    color: '#639674',
}));

// ----------------------------------------------------------------------

export default function ConnectedCases() {
    return (

        <RootStyle>
            <Stack flexDirection='row' mt={2}>
                <IconWrapperStyle>
                    <Icon icon={roundCases} width={350} height={350}/>
                </IconWrapperStyle>
                <Stack flexDirection='column'>
                    <Typography variant="h3" sx={{}}>
                        9
                    </Typography>
                    <Typography variant="subtitle1" paddingLeft={0} paddingTop={1}>
                         Connected Cases
                    </Typography>
                </Stack>
            </Stack>
        </RootStyle>
    );
}

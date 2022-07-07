import baselineTask from '@iconify/icons-ic/baseline-task';
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
    color: '#9e6ea3',
    backgroundColor: '#f4e9f8',
    width: 310,
    height: 184
}));

const IconWrapperStyle = styled('div')(({ theme }) => ({
    margin: 'auto',
    display: 'flex',
    borderRadius: '50%',
    marginLeft: -23,
    paddingTop: 0,
    alignItems: 'center',
    width: theme.spacing(17),
    height: theme.spacing(19),
    justifyContent: 'center',
    color: '#9e6ea3',
}));

// ----------------------------------------------------------------------

export default function ConnectedTasks() {
    return (

        <RootStyle>
            <Stack flexDirection='row' mt={2}>
                <IconWrapperStyle>
                    <Icon icon={baselineTask} width={350} height={350}/>
                </IconWrapperStyle>
                <Stack flexDirection='column'>
                    <Typography variant="h3" sx={{}}>
                        23
                    </Typography>
                    <Typography variant="subtitle1" paddingLeft={0} paddingTop={1}>
                        Connected Tasks
                    </Typography>
                </Stack>
            </Stack>
        </RootStyle>
    );
}

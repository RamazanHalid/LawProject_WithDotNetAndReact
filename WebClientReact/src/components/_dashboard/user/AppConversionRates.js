import {faker} from '@faker-js/faker';
import PropTypes from 'prop-types';
// material
import {Card, Typography, CardHeader, CardContent, Stack} from '@mui/material';
import {
    Timeline,
    TimelineItem,
    TimelineContent,
    TimelineConnector,
    TimelineSeparator,
    TimelineDot
} from '@mui/lab';
// utils
import {Global} from "../../../Global";
import PopupMessageService from "../../../services/popupMessage.service";
import EventsService from "../../../services/events.service";
import React, {useEffect, useState} from "react";
import {format} from "date-fns";
import CircularProgress from "@mui/material/CircularProgress";

// ----------------------------------------------------------------------

export default function AppConversionRates() {
    const catchMessagee = Global.catchMessage;
    const popupMessageService = new PopupMessageService();
    const eventsService = new EventsService();
    const [tasks, setTasks] = useState([]);
    const [tasksNumber, setTasksNumber] = useState([]);
    const [isLoading, setIsLoading] = useState(true);

    const days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
    const monthNames = ["January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"
    ];

    const getLastEvents = () => {
        eventsService.getAllLastEventsByNumber(5).then(
            (result) => {
                if (result.data.Success) {
                    setTasks(result.data.Data)
                    setIsLoading(false)
                    for (let i = 0; i < 5; i += 1) {
                        return tasksNumber.slice(0, 5)
                    }
                }
            },
            (error) => {
                popupMessageService.AlertErrorMessage(error.response.data.Message);
            }
        ).catch(() => {
            popupMessageService.AlertErrorMessage(catchMessagee)
        })
    };

    useEffect(() => {
        getLastEvents()
    }, []);
    return (
        <Card
            sx={{
                '& .MuiTimelineItem-missingOppositeContent:before': {
                    display: 'none'
                }
            }}
        >
            <CardHeader title="Upcoming Events"/>
            <CardContent>
                <Timeline>
                    {isLoading === true ?
                        <Stack sx={{color: 'grey.500', paddingLeft: 50, paddingTop: 25}} spacing={2} direction="row"
                               justifyContent='center' alignSelf='center' left='50%'>
                            <CircularProgress color="inherit"/>
                        </Stack>
                        :

                        <>
                            {tasks.length > 0 ? (
                                    <>
                                        {tasks.map((item, index) => (
                                            <TimelineItem>
                                                <TimelineSeparator>
                                                    <TimelineDot
                                                        sx={{
                                                            backgroundColor:
                                                                (index == tasks.length - 1 && 'success.main') ||
                                                                (index == tasks.length - 2 && 'primary.main') ||
                                                                (index == tasks.length - 3 && 'info.main') ||
                                                                (index == tasks.length - 4 && 'warning.main') ||
                                                                'error.main'
                                                        }}
                                                    />
                                                    <TimelineConnector/>

                                                </TimelineSeparator>
                                                <TimelineContent>
                                                    <Typography variant="subtitle2"
                                                                key={item.EventtId}>{item.Title}</Typography>
                                                    <Typography variant="caption" sx={{color: 'text.secondary'}}>
                                                        {days[new Date(item.StartDate).getDay()]} {monthNames[new Date(item.StartDate).getMonth()]} {format(new Date(item.StartDate), 'dd kk:mm')}
                                                    </Typography>
                                                    <Stack flexDirection='row'>
                                                        <Typography variant="caption" sx={{color: 'text.secondary'}}>
                                                            {days[new Date(item.EndDate).getDay()]} {monthNames[new Date(item.EndDate).getMonth()]} {format(new Date(item.EndDate), 'dd kk:mm')}
                                                        </Typography>
                                                    </Stack>

                                                </TimelineContent>
                                            </TimelineItem>
                                        ))}
                                    </>
                                ) :
                                <>
                                    <Typography variant="h3" gutterBottom textAlign='center'
                                                color='#a9a9a9'>Please Add Event!</Typography>
                                </>
                            }
                        </>
                    }

                </Timeline>
            </CardContent>
        </Card>
    );
}

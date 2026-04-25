import { Box, Button, Paper, TextField, Typography } from "@mui/material";

type Props = {
  closeForm: () => void;
  activity?: Activity;
};

export default function ActivityForm({ closeForm, activity }: Props) {
  return (
    <Paper sx={{ borderRadius: 3, padding: 2 }}>
      <Typography variant="h5" gutterBottom color="primary">
        Create an activity
      </Typography>
      <Box component="form" display="flex" flexDirection="column" gap={3}>
        <TextField label="Title" value={activity?.title} />
        <TextField label="Description" multiline={true} rows={3} />
        <TextField label="Category" />
        <TextField label="Date" type="date" />
        <TextField label="City" />
        <TextField label="Venue" />
        <Box display="flex" gap={3} justifyContent="end">
          <Button onClick={closeForm} color="inherit">
            Cancel
          </Button>
          <Button color="success" variant="contained">
            Submit
          </Button>
        </Box>
      </Box>
    </Paper>
  );
}

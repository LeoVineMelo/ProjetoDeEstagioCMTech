import * as React from 'react';
import Box from '@mui/material/Box';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';

export default function BasicSelect(props) {

  const handleChange = (e) => {
    props.handleChange(e.target.value)
  }

  return (
    <Box sx={{ minWidth: 120 }}>
      <FormControl fullWidth>
        <InputLabel id="demo-simple-select-label">{props.label}</InputLabel>
        <Select
          labelId="demo-simple-select-label"
          id="demo-simple-select"
          value={props.value}
          label={props.label}
          onChange={handleChange}
        >
          <MenuItem value={''}>Selecione um destinatário</MenuItem>
          {props.list && props.list.map(item => <MenuItem value={item.id}>{item.name}</MenuItem>)}
        </Select>
      </FormControl>
    </Box>
  );
}
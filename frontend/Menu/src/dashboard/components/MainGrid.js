import * as React from 'react';  
import Grid from '@mui/material/Grid2';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import Select from '@mui/material/Select';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import InputLabel from '@mui/material/InputLabel';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import Copyright from '../internals/components/Copyright';

export default function MainGrid() {
  const [tipoProblema, setTipoProblema] = React.useState('');
  const [tipoEquipo, setTipoEquipo] = React.useState('');
  const [descripcion, setDescripcion] = React.useState('');
  const [tecnicoSeleccionado, setTecnicoSeleccionado] = React.useState('');
  const [tickets, setTickets] = React.useState([]);

  const handleEnviarTicket = () => {
    console.log('Ticket enviado:', {
      tipoProblema,
      tipoEquipo,
      descripcion,
      tecnicoSeleccionado,
    });
    const newTicket = {
      id: tickets.length + 1,
      estado: 'Activo',
    };
    setTickets([...tickets, newTicket]);
    setTipoProblema('');
    setTipoEquipo('');
    setDescripcion('');
    setTecnicoSeleccionado('');
  };

  return (
    <Box sx={{ width: '100%', maxWidth: { sm: '100%', md: '1700px' } }}>
      <Typography component="h2" variant="h6" sx={{ mb: 2 }}>
        Crear Ticket
      </Typography>
      <Grid container spacing={2} sx={{ mb: 4 }}>
        <Grid item xs={12}>
          <FormControl fullWidth sx={{ mb: 2 }}>
            <InputLabel id="tipo-problema-label">Tipo de problema</InputLabel>
            <Select
              labelId="tipo-problema-label"
              value={tipoProblema}
              label="Tipo de problema"
              onChange={(e) => setTipoProblema(e.target.value)}
            >
              <MenuItem value="Hardware">Hardware</MenuItem>
              <MenuItem value="Software">Software</MenuItem>
            </Select>
          </FormControl>
          <FormControl fullWidth sx={{ mb: 2 }}>
            <InputLabel id="tipo-equipo-label">Tipo de equipo</InputLabel>
            <Select
              labelId="tipo-equipo-label"
              value={tipoEquipo}
              label="Tipo de equipo"
              onChange={(e) => setTipoEquipo(e.target.value)}
            >
              <MenuItem value="Computadora">Computadora</MenuItem>
              <MenuItem value="Servidor">Servidor</MenuItem>
              <MenuItem value="Proyector">Proyector</MenuItem>
            </Select>
          </FormControl>
          <TextField
            fullWidth
            label="Describe tu problema"
            margin="normal"
            value={descripcion}
            onChange={(e) => setDescripcion(e.target.value)}
          />
          <Typography component="h3" variant="h6" sx={{ mb: 2 }}>
            Selecciona un técnico
          </Typography>
          <Grid container spacing={2} sx={{ mb: 2 }}>
            <Grid item xs={4}>
              <Typography>Nombre</Typography>
            </Grid>
            <Grid item xs={4}>
              <Typography>Especialidad</Typography>
            </Grid>
            <Grid item xs={4}>
              <Typography>Gmail</Typography>
            </Grid>
          </Grid>
          <FormControl fullWidth sx={{ mb: 2 }}>
            <InputLabel id="tecnico-label">Técnico</InputLabel>
            <Select
              labelId="tecnico-label"
              value={tecnicoSeleccionado}
              label="Técnico"
              onChange={(e) => setTecnicoSeleccionado(e.target.value)}
            >
            </Select>
          </FormControl>
          <Button
            variant="contained"
            color="primary"
            onClick={handleEnviarTicket}
            sx={{ mt: 2 }}
          >
            Enviar Ticket
          </Button>
        </Grid>
      </Grid>
      <Typography component="h2" variant="h6" sx={{ mb: 2, mt: 4 }}>
        Estado de tickets
      </Typography>
      <TableContainer component={Paper}>
        <Table aria-label="estado de tickets">
          <TableHead>
            <TableRow>
              <TableCell>ID</TableCell>
              <TableCell>Estado</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {tickets.map((ticket) => (
              <TableRow key={ticket.id}>
                <TableCell>{ticket.id}</TableCell>
                <TableCell>{ticket.estado}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
      <Copyright sx={{ my: 4 }} />
    </Box>
  );
}
